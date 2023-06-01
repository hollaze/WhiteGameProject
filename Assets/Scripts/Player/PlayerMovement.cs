using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Scriptable Objects
    [SerializeField] PlayerInputScriptableObject _inputSO;
    [SerializeField] MovementScriptableObject _movementSO;
    #endregion
    [SerializeField] Rigidbody2D _rb;

    private Vector2 _movement;
    private Vector2 _velocity = Vector2.zero;

    void Update()
    {
        SetInputAxis();
    }

    void FixedUpdate()
    {
        Movement();
        Rotation();
    }

    // Set horizontal and vertical input axis
    private void SetInputAxis()
    {
        _movement.x = Input.GetAxis(_inputSO.horizontal);
        _movement.y = Input.GetAxis(_inputSO.vertical);
    }

    // Move on movement input axis
    private void Movement()
    {
        if (UnitState.instance.IsState(UnitState.UnitMovementState.Walk))
        {
            _movement = _movement.normalized;

            _rb.MovePosition(_rb.position + _movement * Time.deltaTime * _movementSO.speed);
        }
    }

    // Rotate on movement input
    private void Rotation()
    {
        // Detect input
        if (_movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, _movement.normalized);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _movementSO.rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
