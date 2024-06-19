using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField] float _maxSpeed;
    [SerializeField] float _lifeTime;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0)
        {
            Destroy(gameObject);
            return;
        }
    }

    void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector3(0, 0, _maxSpeed - GetPlayerHorizontalVelocity()), ForceMode.VelocityChange);
    }

    public float GetPlayerHorizontalVelocity()
    {
        Vector3 value = _rigidbody.velocity;
        return value.z;
    }

}
