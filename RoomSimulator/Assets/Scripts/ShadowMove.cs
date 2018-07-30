﻿/* ShadowMove.cs
 * Written by Tom Birdsong
 * Last Updated 7/22/2018
 * For use by the Clemson University Virtual Reality Club
 *  
 * ShadowMode informed by shadowController object
 */

namespace VRTK {
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ShadowMove : VRTK_InteractableObject {

		//If shadowMode is false object should behave as normal interactable object
		//If shadowMode is true object should snap to XZ plane and display as shadow on move
		private bool shadowMode = true;

		public bool ShadowMode
		{
			get {
				return shadowMode;
			}
			set {
				Debug.Log ("Setting to " + value);
				if (value != shadowMode) {
					if (value == true) {

						//TODO: save rigidbody presets

						Destroy(transform.GetComponent<Rigidbody> ());

						shadowMode = true;

					} else {

						transform.gameObject.AddComponent<Rigidbody> ();

						shadowMode = false;

					}
				}
			}
		}

		//Shadow component to be displayed only while object is grabbed, must be child of current object
		public Transform InteractShadow;

		//Initial Y coordinate to hold shadow at
		private float initShadowY = 0;

		//Initial Y coordinate to hold transform at
		private float initPosY = 0;

		// Use this for initialization
		void Start () {
			//set initial Y coordinates
			initPosY = transform.position.y;
			initShadowY = InteractShadow.position.y;
		}

		//Adjust shadow while needed
		new void Update () {
			base.Update ();

			if (shadowMode && InteractShadow.gameObject.activeSelf == true) {
				shadowFollow ();
			}
		}
			
		public override void Grabbed(VRTK_InteractGrab usingObject)
		{
			base.Grabbed(usingObject);

			if (shadowMode) {
				makeShadow ();
			}
		}

		public override void Ungrabbed(VRTK_InteractGrab usingObject)
		{
			base.Ungrabbed (usingObject);

			if (shadowMode) {
				makeVisible ();
			}
		}

		//When grabbed, deactivate all subcomponents and then render designated shadow
		public void makeShadow() {
			foreach(Transform t in transform) {
				t.gameObject.SetActive(false);
			}

			InteractShadow.gameObject.SetActive (true);
			InteractShadow.gameObject.GetComponent<MeshCollider> ().enabled = false;
		}

		//When ungrabbed, re-activate all subcomponents and then deactivate shadow
		private void makeVisible() {
			foreach (Transform t in transform) {
				t.gameObject.SetActive (true);
			}

			InteractShadow.gameObject.SetActive (false);
		}

		//While grabbed, hold shadow at constant Y-coordinate and only allow rotation on Y-axis
		private void shadowFollow() {
			Vector3 startRot = transform.rotation.eulerAngles;
			transform.rotation = Quaternion.Euler(0,startRot.y,0);
 
			if (transform.position.y != initPosY) {
				transform.position = new Vector3 (transform.position.x, initPosY, transform.position.z);
			}
		}

		public static void setShadowMode(bool mode) {

		}
	}
}
