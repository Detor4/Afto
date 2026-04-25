using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace EasyVehicleSteering
{
	public class GasButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		public float accelerationValue = 1f; // 1 for Gas, -1 for Brake
		private bool isHeld = false;

		public void OnPointerDown(PointerEventData eventData)
		{
			isHeld = true;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			isHeld = false;
			InputHandler.ClearSimulatedVertical();
		}

		void Update()
		{
			if (isHeld)
			{
				InputHandler.SetSimulatedVertical(accelerationValue);
			}
		}

		void OnDisable()
		{
			isHeld = false;
			InputHandler.ClearSimulatedVertical();
		}
	}
}
