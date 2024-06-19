using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;
    float _moveValue = 0;
    [SerializeField] float _maxSpeed;
    [SerializeField] Animator _animator;
    [SerializeField] Transform _spawnLocation;
    [SerializeField] GameObject _bullet;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMove();
    }

    private void HandleMove()
    {
        _rigidbody.AddForce(new Vector3(_maxSpeed * _moveValue - GetPlayerHorizontalVelocity(), 0, 0), ForceMode.VelocityChange);
        HandleMoveAnimation();
    }

    void HandleMoveAnimation()
    {
        if (_moveValue > 0)
        {
            _animator.Play("MoveRight");
        }
        else if (_moveValue < 0)
        {
            _animator.Play("MoveLeft");
        }
        else
        {
            _animator.Play("Idle");
        }
    }

    public void OnThrowFood(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var bullet = Instantiate(_bullet, _spawnLocation);
            bullet.transform.parent = null;
        }
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
