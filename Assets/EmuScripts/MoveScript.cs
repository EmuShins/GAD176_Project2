using UnityEngine;

public class MoveScript : StartupScript
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    protected void MoveTo(Rigidbody startPos, Vector3 moveDirection)
    {
        Debug.Log("MoveTo has been reached.");

        startPos.AddForce(moveDirection);
    }

     protected void FindPlayerRigid()
    {
        playerRigid=FindFirstObjectByType<PlayerController>().GetComponentInParent<Rigidbody>();
        if(playerRigid==null)
        {
            Debug.Log("uhoh, the player's rigidbody wasnt founnd.");
        }
    }
}   
