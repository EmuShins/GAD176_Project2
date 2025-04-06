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

    public void GetKeyInputs(int moveSpeed)
    {
        FindPlayerRigid();
        if(Input.anyKey)
        {
            Debug.Log("Get key inputs has been reached. playerRigid is:" + playerRigid);

            if(Input.GetKey(KeyCode.W))
            {  
                Vector3 moveIn= new Vector3(playerRigid.transform.forward.x*moveSpeed, playerRigid.transform.forward.y*moveSpeed, playerRigid.transform.forward.z*moveSpeed);
                MoveTo(playerRigid, moveIn);

            }
            if(Input.GetKey(KeyCode.A))
            {
                Vector3 moveIn= new Vector3(-playerRigid.transform.right.x*moveSpeed, -playerRigid.transform.right.y*moveSpeed, -playerRigid.transform.right.z*moveSpeed);
                MoveTo(playerRigid, moveIn);
            }
            if(Input.GetKey(KeyCode.S))
            {
                Vector3 moveIn= new Vector3(-playerRigid.transform.forward.x*moveSpeed, -playerRigid.transform.forward.y*moveSpeed, -playerRigid.transform.forward.z*moveSpeed);
                MoveTo(playerRigid, moveIn);
            }
            if(Input.GetKey(KeyCode.D))
            {
                Vector3 moveIn= new Vector3(playerRigid.transform.right.x*moveSpeed, playerRigid.transform.right.y*moveSpeed, playerRigid.transform.right.z*moveSpeed);
                MoveTo(playerRigid, moveIn);
            }

        }
    }
    
}
