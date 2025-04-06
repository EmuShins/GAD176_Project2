using UnityEngine;

public class StartupScript : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody playerRigid;
    public GameObject player;

    void Start()
    {
        SetupScene();
    }

    private void SetupScene()
    {
        if(FindFirstObjectByType<PlayerController>() != null)
        {
            Debug.Log("A player was already found in the scene. No need to make a new one.");

        }
        else
        {
            Debug.Log("A player wasn't found in the scene. Creating a new one.");
            Instantiate(player, Vector3.zero, Quaternion.identity);
        }
    }

}
