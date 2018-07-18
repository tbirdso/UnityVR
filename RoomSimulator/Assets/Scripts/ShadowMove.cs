namespace VRTK {
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ShadowMove : VRTK_InteractableObject {

		public Transform InteractShadow;

		private float initShadowY = 0;
		private float initTableY = 0;

		// Use this for initialization
		/*override void Start () {
			base.Start ();
			Debug.Log ("Started.");
		}*/

		new void Update () {
			base.Update ();

			if (InteractShadow.gameObject.activeSelf == true) {
				shadowFollow ();
			}
		}

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
				t.gameObject.SetActive(false);
			}

			InteractShadow.gameObject.SetActive (true);
			InteractShadow.gameObject.GetComponent<MeshCollider> ().enabled = false;

			initTableY = transform.position.y;
		}

		private void makeVisible() {

			Vector3 adjPos = transform.position;
			adjPos.y = initTableY;
			transform.SetPositionAndRotation (adjPos, transform.rotation);			

			foreach (Transform t in transform) {
				t.gameObject.SetActive (true);
			}
				
			InteractShadow.gameObject.SetActive (false);
		}

		private void shadowFollow() {
			if (InteractShadow.position.y != initShadowY) {
				Vector3 shadowPos = InteractShadow.position;
				shadowPos.y = initShadowY;
				InteractShadow.SetPositionAndRotation (shadowPos, InteractShadow.rotation);
			}
		}
	}
}
