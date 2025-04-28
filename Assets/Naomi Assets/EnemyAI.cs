using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public PathingNodeNames pathingNodeNames;
    public EnemyTypeValues enemyAI;
    private float movementSpeed;
    private int currentNodeNumber = 0;
    protected Vector3 lookDirection;
    protected Quaternion targetRotation;
    public List<PatrolScript> pathNode = new List<PatrolScript>();

    LayerMask layerMask;



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

        layerMask = LayerMask.GetMask("Wall", "Character");
        GeneratePathing(pathingNodeNames.node);


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

        AIMover();
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.forward * 100);
    }

    void AIMover()
    {
        //check if we are on the node
        //if we are, find next node
        //else, move

        

        if ((this.gameObject.transform.position - pathNode[currentNodeNumber].transform.position).magnitude >= 1f)
        {
            lookDirection = (pathNode[currentNodeNumber].transform.position - this.transform.position).normalized;
            targetRotation = Quaternion.LookRotation(lookDirection);
            this.gameObject.transform.position = Vector3.Lerp(transform.position, pathNode[currentNodeNumber].transform.position, Time.deltaTime * movementSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1000);
        }
        else
        {
            currentNodeNumber++;
            currentNodeNumber %= pathNode.Count;
        }
    }

    void GeneratePathing(string setPath)
    { 
            //Checks for a pathing node name on itself, then finds all nodes in the scene with same pathing node name
            if (pathingNodeNames != null)
            {
                PatrolScript[] tempArray = FindObjectsByType<PatrolScript>(FindObjectsSortMode.InstanceID);

                foreach (PatrolScript ps in tempArray)
                {
                    if (ps.pathingNodeNames.node == setPath)
                        pathNode.Add(ps);
                }
            }
        
    }
}
