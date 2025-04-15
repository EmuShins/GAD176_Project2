using Unity.VisualScripting;
using UnityEngine;

public class MoveScript : BaseScript
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
        playerRigid=player.GetComponent<Rigidbody>();
        if(playerRigid==null)
        {
            Debug.Log("uhoh, the player's rigidbody wasnt founnd.");
        }
    }

    protected void Jump(Rigidbody startPos, float jumpHeight)
    {
        startPos.AddForce(transform.up*jumpHeight);
    }

    protected virtual void Crouch(Rigidbody startPos) 
    {
        Debug.Log("The player is now crouched.");
    }

}   
