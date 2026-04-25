using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace EasyVehicleSteering
{
	public static class InputHandler
	{
		private static bool useSimulatedHorizontal = false;
		private static float simulatedHorizontal = 0f;

		private static bool useSimulatedVertical = false;
		private static float simulatedVertical = 0f;

		public static void SetSimulatedHorizontal(float value)
		{
			simulatedHorizontal = Mathf.Clamp(value, -1f, 1f);
			useSimulatedHorizontal = true;
		}

		public static void ClearSimulatedHorizontal()
		{
			simulatedHorizontal = 0f;
			useSimulatedHorizontal = false;
		}

		public static void SetSimulatedVertical(float value)
		{
			simulatedVertical = Mathf.Clamp(value, -1f, 1f);
			useSimulatedVertical = true;
		}

		public static void ClearSimulatedVertical()
		{
			simulatedVertical = 0f;
			useSimulatedVertical = false;
		}

		public static float Horizontal
		{
			get
			{
				if (useSimulatedHorizontal)
				{
					return simulatedHorizontal;
				}
				
				return CrossPlatformInputManager.GetAxis("Horizontal");
			}
		}

		public static float Vertical
		{
			get
			{
				if (useSimulatedVertical)
				{
					return simulatedVertical;
				}
				
				return CrossPlatformInputManager.GetAxis("Vertical");
			}
		}
	}

}
