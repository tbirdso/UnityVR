namespace VRTK {
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class move_rope : VRTK_InteractableObject {

		private bool ropeIsOn;

		// Use this for initialization
		void Start () {
			GameObject ropeObj = transform.Find ("rope").gameObject;
			ropeIsOn = ropeObj.activeSelf ;
		}

		public override void StartUsing(VRTK_InteractUse usingObject)
		{
			base.StartUsing(usingObject);
			toggleRope ();
		}

		public void toggleRope() {
			GameObject ropeObj = transform.Find("rope").gameObject;
			if (ropeObj) {
				if (!ropeIsOn) {
					ropeObj.SetActive (true);
					ropeIsOn = true;
				} else {
					ropeObj.SetActive(false);
					ropeIsOn = false;
				}
			} else {
				Debug.Log ("Attempted to toggle stanchion but rope was not found.");
			}

		}
	}
}
