using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerInputScriptableObject _inputSO;
    [SerializeField] MovementScriptableObject _movementSO;
    [SerializeField] Rigidbody2D _rb;

    private Vector2 _movement;
    private Vector2 _velocity = Vector2.zero;

    void Update()
    {
        _movement.x = Input.GetAxis(_inputSO.horizontal);
        _movement.y = Input.GetAxis(_inputSO.vertical);
    }

    void FixedUpdate()
    {
        Movement();
        Rotation();
    }

    // Move on movement input
    public void Movement()
    {
        if (UnitState.instance.IsState(UnitState.UnitMovementState.Walk))
        {
            _rb.MovePosition(_rb.position + _movement * _movementSO.speed * Time.fixedDeltaTime);
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
