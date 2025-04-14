using UnityEngine;

public class InputScript : MoveScript
{
    void Start()
    {
        FindPlayerRigid();
    }

    void Update()
    {
        
    }

    public void GetKeyInputs(int moveSpeed, int sprintSpeed, float jumpHeight, bool isCrouched)
    {
        FindPlayerRigid();
        //WASD movement
        if (Input.anyKey)
        {
            Debug.Log("Get key inputs has been reached. playerRigid is:" + playerRigid);
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    MoveTo(playerRigid, transform.forward * moveSpeed);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    MoveTo(playerRigid, -transform.right * moveSpeed);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    MoveTo(playerRigid, -transform.forward * moveSpeed);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    MoveTo(playerRigid, transform.right * moveSpeed);
                }
            }
            //Sprint
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    MoveTo(playerRigid, transform.forward * sprintSpeed);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    MoveTo(playerRigid, -transform.right * sprintSpeed);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    MoveTo(playerRigid, -transform.forward * sprintSpeed);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    MoveTo(playerRigid, transform.right * sprintSpeed);
                }
            }
            //Jump
            if (Input.GetKey(KeyCode.Space))
            {
                if(Physics.Raycast(transform.position, Vector3.down, 1))
                {
                    Debug.Log("The player can jump");
                    Jump(playerRigid, jumpHeight);
                }
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                Crouch(playerRigid, isCrouched);
            }
        }
    }
}
