using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace EasyVehicleSteering
{
	public static class InputHandler
	{
		private static bool useSimulatedHorizontal = false;
		private static float simulatedHorizontal = 0f;

		private static bool useSimulatedAccel = false;
		private static float simulatedAccel = 0f;

		private static bool useSimulatedBrake = false;
		private static float simulatedBrake = 0f;

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

		public static void SetSimulatedAccel(float value)
		{
			simulatedAccel = Mathf.Clamp01(value);
			useSimulatedAccel = true;
		}

		public static void ClearSimulatedAccel()
		{
			simulatedAccel = 0f;
			useSimulatedAccel = false;
		}

		public static void SetSimulatedBrake(float value)
		{
			simulatedBrake = Mathf.Clamp01(value);
			useSimulatedBrake = true;
		}

		public static void ClearSimulatedBrake()
		{
			simulatedBrake = 0f;
			useSimulatedBrake = false;
		}

		public static float Horizontal => useSimulatedHorizontal ? simulatedHorizontal : CrossPlatformInputManager.GetAxis("Horizontal");

		public static float Accel
		{
			get
			{
				if (useSimulatedAccel) return simulatedAccel;
				return Mathf.Max(0, CrossPlatformInputManager.GetAxis("Vertical"));
			}
		}

		public static float Brake
		{
			get
			{
				if (useSimulatedBrake) return simulatedBrake;
				return Mathf.Max(0, -CrossPlatformInputManager.GetAxis("Vertical"));
			}
		}
	}


}
