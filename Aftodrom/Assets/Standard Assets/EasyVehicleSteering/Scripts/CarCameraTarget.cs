using UnityEngine;

namespace EasyVehicleSteering
{
    public class CarCameraTarget : MonoBehaviour
    {
        public Transform carTransform;
        public float rotationSpeed = 5f;
        public float moveSpeed = 10f;
        
        // Offset from car to look at
        public Vector3 lookAtOffset = new Vector3(0, 1.5f, 0);
        
        void Update()
        {
            if (carTransform == null) return;

            // Follow position
            transform.position = Vector3.Lerp(transform.position, carTransform.position + lookAtOffset, Time.deltaTime * moveSpeed);

            // Follow rotation (only Y axis to keep it stable)
            Vector3 targetForward = carTransform.forward;
            targetForward.y = 0;
            if (targetForward != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetForward, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
}
