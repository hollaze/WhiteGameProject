using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] HealthScriptableObject _healthSO;

    private float _maxHealth;
    private float _currentHealth;
    public bool alive = true;

    private void SetHealth()
    {
        _currentHealth = _maxHealth = _healthSO.health;

        if (_currentHealth < 0)
            Debug.LogError("Health not set on : " + this.gameObject.name);
    }

    void Awake()
    {
        SetHealth();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Max Health : " + _maxHealth);
    }

    private void Die()
    {
        if (_currentHealth <= 0)
        {
            Mathf.Clamp(_currentHealth, 0, _maxHealth);

            if (alive)
                Debug.Log("Dead");

            alive = false;
        }
    }

    void Update()
    {
        Die();
    }

    /// <summary>
    /// Current unit takes damage
    /// </summary>
    /// <param name="damageAmount"></param>
    public void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;
        Debug.Log("DAMAGE : Current health : " + _currentHealth);
    }

    /// <summary>
    /// Current unit takes heal
    /// </summary>
    /// <param name="healAmount"></param>
    public void Heal(float healAmount)
    {
        _currentHealth += healAmount;
        Debug.Log("HEAL : Current health : " + _currentHealth);
    }
}
