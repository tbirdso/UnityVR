using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class shadowController : MonoBehaviour {

	public bool globalShadowMode = true;

	public VRTK_InteractableObject[] activateTriggers;
	public VRTK_InteractableObject[] deactivateTriggers;

	public ShadowMove[] shadowables;

	// Use this for initialization
	void Start () {
		foreach (VRTK_InteractableObject s in activateTriggers) {
			s.InteractableObjectUsed += new InteractableObjectEventHandler(setGlobalMode);
		}
		foreach (VRTK_InteractableObject s in deactivateTriggers) {
			s.InteractableObjectUsed += new InteractableObjectEventHandler (setGlobalMode);
		}
	}

	private void setGlobalMode(object sender, InteractableObjectEventArgs e) {
		Debug.Log ("switching");
		globalShadowMode = !globalShadowMode;

		foreach (ShadowMove s in shadowables) {
			s.ShadowMode = globalShadowMode;
		}
	}
}
