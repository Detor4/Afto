using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace EasyVehicleSteering
{
	public enum InputType { Accel, Brake }

	public class GasButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		public InputType type = InputType.Accel;
		public float value = 1f;
		private bool isHeld = false;

		public void OnPointerDown(PointerEventData eventData)
		{
			isHeld = true;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			isHeld = false;
			ClearInput();
		}

		void Update()
		{
			if (isHeld)
			{
				if (type == InputType.Accel)
					InputHandler.SetSimulatedAccel(value);
				else
					InputHandler.SetSimulatedBrake(value);
			}
		}

		void ClearInput()
		{
			if (type == InputType.Accel)
				InputHandler.ClearSimulatedAccel();
			else
				InputHandler.ClearSimulatedBrake();
		}

		void OnDisable()
		{
			isHeld = false;
			ClearInput();
		}
	}
}

