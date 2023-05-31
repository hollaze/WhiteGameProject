using UnityEngine;

[CreateAssetMenu(fileName = "Movement", menuName = "ScriptableObjects/MovementScriptableObject")]
public class MovementScriptableObject : ScriptableObject
{
    public float speed;
    public float rotationSpeed;
}
