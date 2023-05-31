using System.Net.Mime;
using UnityEngine;

[CreateAssetMenu(fileName = "Input", menuName = "ScriptableObjects/PlayerInputScriptableObject")]
[Tooltip("Input actions")]
public class PlayerInputScriptableObject : ScriptableObject
{
    // Horizontal and vertical movement
    [HideInInspector]
    public string horizontal = "Horizontal";
    [HideInInspector]
    public string vertical = "Vertical";

    [Header("Actions")]
    [Tooltip("Attack input, 0 for left click")]
    public int Attack = 0;
    [Tooltip("Defense input, 1 for right click")]
    public int Defense = 1;
}
