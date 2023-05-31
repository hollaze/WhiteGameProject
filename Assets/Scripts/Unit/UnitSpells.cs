using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpells : MonoBehaviour
{
    [SerializeField] SpellsScriptableObject _spellsSO;
    private Rigidbody2D _rb;
    private Vector2 _moveDirection = Vector2.zero;

    private float _dashDelay;
    private float _nextDashDelay;
    private bool _isDashing = false;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetDashDelay();
        SetNextDashDelay();

        Debug.Log($"Dash delay =  {_dashDelay}  : Dash delay SO = {_spellsSO.dashDelay}");
        Debug.Log($"Dash delay = {_nextDashDelay}  : Dash delay SO = {_spellsSO.nextDashDelay}");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _isDashing == false)
        {
            _isDashing = true;
            UnitState.instance.unitMovementState = UnitState.UnitMovementState.Dash;
        }
    }

    void FixedUpdate()
    {
        Dash();
    }

    /// <summary>
    /// Makes unit dash
    /// </summary>
    public void Dash()
    {
        if (_isDashing)
        {
            if (UnitState.instance.IsState(UnitState.UnitMovementState.Dash))
            {
                if (_dashDelay == _spellsSO.dashDelay)
                {
                    _rb.AddForce(transform.up * _spellsSO.dashForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
                    //_rb.velocity = new Vector2(_rb.velocity.x * _spellsSO.dashForce, _rb.velocity.y * _spellsSO.dashForce);

                    Debug.Log("Dash");
                }

                _dashDelay -= Time.deltaTime;

                if (_dashDelay <= 0)
                {
                    SetDashDelay();

                    UnitState.instance.unitMovementState = UnitState.UnitMovementState.Walk;

                    _rb.velocity = Vector2.zero;

                    Debug.Log("Stop Dash");
                }
            }

            else if (UnitState.instance.IsState(UnitState.UnitMovementState.Walk))
            {
                if (_nextDashDelay <= _spellsSO.dashDelay && _nextDashDelay <= 0)
                {
                    _isDashing = false;

                    SetNextDashDelay();

                    Debug.Log("Dash Available");

                    return;
                }

                _nextDashDelay -= Time.deltaTime;
            }
        }
    }

    private void SetDashDelay()
    {
        _dashDelay = _spellsSO.dashDelay;
    }

    private void SetNextDashDelay()
    {
        _nextDashDelay = _spellsSO.nextDashDelay;
    }
}
