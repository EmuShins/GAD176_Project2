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
                MoveTo(playerRigid, transform.forward*moveSpeed);
            }
            if(Input.GetKey(KeyCode.A))
            { 
                MoveTo(playerRigid, -transform.right * moveSpeed);
            }
            if(Input.GetKey(KeyCode.S))
            {
                MoveTo(playerRigid, -transform.forward * moveSpeed);
            }
            if(Input.GetKey(KeyCode.D))
            {
                MoveTo(playerRigid, transform.right * moveSpeed);
            }

        }
    }
    
}
