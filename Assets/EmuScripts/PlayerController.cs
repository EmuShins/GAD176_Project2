using TMPro.EditorUtilities;
using UnityEngine;

namespace GAD176.Emu.Player
{
    public class PlayerController : InputScript
    {
        [SerializeField]
        public bool isCrouched;
        public GameObject playerCamera;
        public ControllerScriptable controllerSettings;

        void Start()
        {
        }
        void OnEnable()
        {
        }
        
        void Update()
        {
            GetKeyInputs(controllerSettings.moveSpeed, controllerSettings.sprintSpeed, controllerSettings.jumpHeight);
            isCrouched = GetCrouchInput(isCrouched);

            if (playerCamera != null)
            {
                MoveCamera(playerCamera);
            }
        }

        public virtual void MoveCamera(GameObject thisCamera)
        {
            float mouseX = Input.GetAxis("Mouse X") * controllerSettings.mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * controllerSettings.mouseSensitivity;

            yRotation -= mouseY;
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);
            thisCamera.transform.localEulerAngles = Vector3.right * yRotation;
            this.transform.Rotate(Vector3.up * mouseX);
        }
    }
        
}

