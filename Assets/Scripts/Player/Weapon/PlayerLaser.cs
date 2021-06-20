using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    private float _speed = 20.0f;
    private float _destroyCoolDown = 3.0f;
    private Transform _transform;

    private void Start()
    {
        _transform = _transform == null ? GetComponent<Transform>() : _transform;
        Destroy(gameObject, _destroyCoolDown);
    }
    private void FixedUpdate()
    {
        _transform.position += Vector3.up * _speed * Time.deltaTime;
    }
}
