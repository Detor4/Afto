using UnityEngine;
using UnityEngine.UI;

namespace EasyVehicleSteering
{
	public class GearButton : MonoBehaviour
	{
		public bool setReverse = false;
		private Button button;

		void Start()
		{
			button = GetComponent<Button>();
			if (button != null)
			{
				button.onClick.AddListener(SetGear);
			}
		}

		public void SetGear()
		{
			InputHandler.IsReverseGear = setReverse;
			Debug.Log("Gear set to: " + (setReverse ? "Reverse" : "Forward"));
		}
	}
}
