using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;
    float _moveValue = 0;
    [SerializeField] float _maxSpeed;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMove();
    }

    private void HandleMove()
    {
        _rigidbody.AddForce(new Vector3(_maxSpeed * _moveValue - GetPlayerHorizontalVelocity(), 0, 0), ForceMode.VelocityChange);
    }

    public void OnThrowFood()
    {
        Debug.Log("FOOD");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveValue = context.ReadValue<float>();

    }

    public float GetPlayerHorizontalVelocity()
    {
        Vector3 value = _rigidbody.velocity;
        return value.x;
    }
}
