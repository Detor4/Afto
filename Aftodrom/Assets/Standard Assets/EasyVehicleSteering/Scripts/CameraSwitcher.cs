using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

namespace EasyVehicleSteering
{
    public class CameraSwitcher : MonoBehaviour
    {
        [Header("Cameras")]
        public CinemachineVirtualCamera[] cameras;
        
        [Header("Settings")]

        public Button switchButton;
        public int activePriority = 20;
        public int inactivePriority = 10;
        
        private int currentCameraIndex = 0;

        void Start()
        {
            if (switchButton != null)
            {
                switchButton.onClick.AddListener(SwitchCamera);
            }

            // Set initial priorities
            UpdateCameraPriorities();
        }

        public void SwitchCamera()
        {
            if (cameras == null || cameras.Length == 0) return;
            
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
            UpdateCameraPriorities();
        }

        void UpdateCameraPriorities()
        {
            if (cameras == null) return;

            for (int i = 0; i < cameras.Length; i++)
            {
                if (cameras[i] != null)
                {
                    cameras[i].Priority = (i == currentCameraIndex) ? activePriority : inactivePriority;
                }
            }
        }
    }

}
