using Unity.VisualScripting;
using UnityEngine;

namespace GAD176.Emu.Player
{
    public class MoveScript : BaseScript
    {
        protected void MoveTo(Rigidbody startPos, Vector3 moveDirection)
        {
            Debug.Log("MoveTo has been reached.");

            startPos.AddForce(moveDirection);
        }

        protected void FindPlayerRigid()
        {
            playerRigid = player.GetComponent<Rigidbody>();
            if (playerRigid == null)
            {
                Debug.Log("uhoh, the player's rigidbody wasnt found.");
            }
        }

        protected void Jump(Rigidbody startPos, float jumpHeight)
        {
            startPos.AddForce(transform.up * jumpHeight);

            //Uneccesary code, Just a demonstration for LO's.
            Debug.Log("Jumped " + (transform.up * jumpHeight).magnitude + " units. in the " + (transform.up * jumpHeight).normalized + " direction.");
        }

        protected virtual void Crouch(Rigidbody startPos)
        {
            Debug.Log("The player is now crouched.");
        }

    }
}
