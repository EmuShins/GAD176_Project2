using TMPro;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyTypeValues enemyAI;
    private float movementSpeed;
    LayerMask layerMask = LayerMask.GetMask("Wall", "Character");
    //On Validate, when the scriptable object is dragged onto the game object in the inspector this runs.
    private void OnValidate()
    {
        //null check, then sets the attached game objects variables to match the enemy type to whatever number is set in the scriptable object.
        if (enemyAI != null)
        {
            this.gameObject.transform.localScale = new Vector3(enemyAI.scale, enemyAI.scale, enemyAI.scale);
            movementSpeed = enemyAI.movementSpeed;
        }
    }
    void Start()
    {
        LayerMask layerMask = LayerMask.GetMask("Wall", "Character");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))

        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

    }

    private void OnDrawGizmos()
    {
      
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.forward * 100);
    }


}
