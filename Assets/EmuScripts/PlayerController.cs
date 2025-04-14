using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerController : InputScript, IPlayerMovement
{
  float maxSpeed;
  int moveSpeed;
  int sprintSpeed;
    float jumpHeight;
  float moveMass;
  float moveDamp;
    bool isCrouched;

   private float mouseSensitivity;
   private float yRotation;
   public GameObject playerCamera;

    void Start()
    {
        Initialization();
    }

    private void OnDrawGizmos()
    {
      DebugLines();
    }

    void Update()
    {
        GetKeyInputs(moveSpeed, sprintSpeed, jumpHeight, isCrouched);

        MoveCamera(playerCamera);
    }

    public void Initialization()
    {
      maxSpeed=1;
      moveSpeed=5;
        sprintSpeed = 50;
        jumpHeight = 100;
      moveMass=1;
      moveDamp=3;
      mouseSensitivity = 2f;
      yRotation = 0f;
    }

    public void DebugLines()
    {
      Debug.DrawRay(transform.position, transform.forward, Color.red);
      Debug.DrawRay(transform.position, -transform.forward, Color.red);
      Debug.DrawRay(transform.position, -transform.right, Color.blue);
      Debug.DrawRay(transform.position, transform.right, Color.blue);
    }

    public void MoveCamera(GameObject thisCamera)
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        thisCamera.transform.localEulerAngles = Vector3.right * yRotation;
        this.transform.Rotate(Vector3.up * mouseX);

    }
}

