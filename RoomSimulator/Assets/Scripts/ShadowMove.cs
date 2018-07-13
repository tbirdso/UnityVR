namespace VRTK {
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ShadowMove : VRTK_InteractableObject {

		private string shadowTag = "Shadow";

		// Use this for initialization
		/*override void Start () {
			base.Start ();
			Debug.Log ("Started.");
		}*/

		public override void Grabbed(VRTK_InteractGrab usingObject)
		{
			base.Grabbed(usingObject);
			makeShadow ();
		}

		public override void Ungrabbed(VRTK_InteractGrab usingObject)
		{
			base.Ungrabbed (usingObject);
			makeVisible ();
		}

		public void makeShadow() {
			foreach(Transform t in transform) {
				if (t.tag.ToString().Equals(shadowTag)) {
					t.gameObject.SetActive(true);
					t.gameObject.GetComponent<MeshCollider> ().enabled = false;
				} else {
					t.gameObject.SetActive(false);
				}
			}

		}

		private void makeVisible() {
			foreach(Transform t in transform) {
				if (t.tag == shadowTag) {
					t.gameObject.SetActive(false);					
				} else {
					t.gameObject.SetActive(true);
				}
			}
		}
	}
}
