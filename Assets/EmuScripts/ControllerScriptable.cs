using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName ="ScriptableController", menuName ="ScriptableObjects/Scriptable Controller")]
public class ControllerScriptable : ScriptableObject
{
    public int maxSpeed=1;
    public int moveSpeed=5;
    public int sprintSpeed=50;
    public float jumpHeight=100;
    public float moveMass=1;
    public float moveDamp=3;
    public float mouseSensitivity=2f;
}
