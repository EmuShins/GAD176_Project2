using UnityEngine;

public class DebugScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DebugLines();
    }

    public void DebugLines()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        Debug.DrawRay(transform.position, -transform.forward, Color.red);
        Debug.DrawRay(transform.position, -transform.right, Color.blue);
        Debug.DrawRay(transform.position, transform.right, Color.blue);
    }
}
