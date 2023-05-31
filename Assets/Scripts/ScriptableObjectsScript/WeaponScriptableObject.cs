using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/WeaponScriptableObject")]
[Tooltip("Weapon stats")]
public class WeaponScriptableObject : ScriptableObject
{
    public float weaponDamage;
}
