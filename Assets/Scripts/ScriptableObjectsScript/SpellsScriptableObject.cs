using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spells", menuName = "ScriptableObjects/SpellsScriptableObject")]
public class SpellsScriptableObject : ScriptableObject
{
    public float dashForce;
    [Tooltip("Delay before next dash, in seconds")]
    public float nextDashDelay;
    [Tooltip("How much time the dash is ongoing, in seconds")]
    public float dashDelay;
}
