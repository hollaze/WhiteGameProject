using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] WeaponScriptableObject _weaponSO;
    public float damage { get; set; }

    void Awake()
    {
        damage = _weaponSO.weaponDamage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Damage unit if weapon touches it
        if (other.gameObject.layer == LayerMask.NameToLayer("Unit"))
        {
            if (other.GetComponent<UnitHealth>().alive)
            {
                other.GetComponent<UnitHealth>().TakeDamage(damage);
            }
        }
    }
}
