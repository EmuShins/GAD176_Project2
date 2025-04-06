using UnityEngine;

public class PlayerController : InputScript, IPlayerMovement
{
  float maxSpeed;
  int moveSpeed;
  float moveMass;
  float moveDamp;

    void Start()
    {
        MovementStatistics();
    }

    private void OnDrawGizmos()
    {
      DebugLines();
    }

    void Update()
    {
      GetKeyInputs(moveSpeed);
    }

    public void MovementStatistics()
    {
      maxSpeed=1;
      moveSpeed=5;
      moveMass=1;
      moveDamp=3;
    }

    public void DebugLines()
    {
      Debug.DrawRay(transform.position, transform.forward, Color.red);
      Debug.DrawRay(transform.position, -transform.forward, Color.red);
      Debug.DrawRay(transform.position, -transform.right, Color.blue);
      Debug.DrawRay(transform.position, transform.right, Color.blue);
    }
}
