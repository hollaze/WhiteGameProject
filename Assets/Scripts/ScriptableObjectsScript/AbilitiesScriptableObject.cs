using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Abilities", menuName = "ScriptableObjects/AbilitiesScriptableObject")]
public class AbilitiesScriptableObject : ScriptableObject
{
    public float dashForce;
    [Tooltip("Delay before next dash, in seconds")]
    public float nextDashDelay;
    [Tooltip("How much time the dash is ongoing, in seconds")]
    public float dashDelay;
}
