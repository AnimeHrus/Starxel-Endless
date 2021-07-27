using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyLaserMovement : MonoBehaviour
{
    [SerializeField]
    private float _velocity;
    [SerializeField]
    private float _amplitudeMove;
    [SerializeField]
    private float _frequencyMove;
    private Rigidbody2D _rigidBody;
    private float _startZRotation;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _startZRotation = transform.localRotation.z;
    }

    private void FixedUpdate()
    {
        AddVelocity();
        
    }

    private void Update()
    {
        ChangeAngle();
    }

    private void AddVelocity()
    {
        _rigidBody.velocity = transform.up * _velocity;
    }

    private void ChangeAngle()
    {
        transform.localRotation *= Quaternion.Euler(0, 0, Mathf.Cos(Time.time * _amplitudeMove) * _frequencyMove);
    }
}
