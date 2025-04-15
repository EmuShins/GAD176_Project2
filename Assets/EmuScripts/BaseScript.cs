using UnityEngine;

public class BaseScript : MonoBehaviour
{
    protected Rigidbody playerRigid;
    public static Transform player;

    void Start()
    {
        SetupScene();
    }
    void Update()
    {
        
    }

    private void SetupScene()
    {
        if (FindFirstObjectByType<PlayerController>() != null)
        {
            Debug.Log("A player was found in the scene.");
            player=FindFirstObjectByType<PlayerController>().GetComponent<Transform>();

        }
        else
        {
            Debug.LogWarning("A player wasn't found in the scene.");
        }
   
    }

}
