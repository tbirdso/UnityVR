namespace VRTK {
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

		public class move_rope : VRTK_InteractableObject {

		private bool ropeIsOn = false;

		// Use this for initialization
		void Start () {
			
		}

			public override void StartUsing(VRTK_InteractUse usingObject)
			{
				Debug.Log ("I am using!");
				base.StartUsing(usingObject);
				toggleRope ();
			}

		public void toggleRope() {
			GameObject ropeObj = transform.Find ("rope").gameObject;
			if (ropeObj) {
				Debug.Log ("Found the rope on this stanchion!");
				if (!ropeIsOn) {
					ropeObj.SetActive (true);
					ropeIsOn = true;
				} else {
					ropeObj.SetActive(false);
					ropeIsOn = false;
				}
			} else {
				Debug.Log ("Attempted to toggle but rope was not found.");
			}

		}
	}
}
