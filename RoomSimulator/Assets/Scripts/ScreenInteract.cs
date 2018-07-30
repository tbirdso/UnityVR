namespace VRTK {

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ScreenInteract : VRTK_InteractableObject {

		public shadowController targetController;

		public delegate void clickAction();
		public event clickAction OnClicked;
		public event clickAction OffClicked;


		public override void StartUsing(VRTK_InteractUse usingObject)
		{
			base.StartUsing(usingObject);

			if (OnClicked != null) {
				OnClicked ();
			}
		}

		public override void StopUsing(VRTK_InteractUse usingObject)
		{
			base.StopUsing(usingObject);

			if (OffClicked != null) {
				OffClicked ();
			}
		}

	}

}