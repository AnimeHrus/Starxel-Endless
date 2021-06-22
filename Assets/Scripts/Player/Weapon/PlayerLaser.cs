using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class PlayerLaser : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    private const float _speed = 20f;
    private const float _destroyCoolDown = 3f;

    private void Start()
    {
        Destroy(gameObject, _destroyCoolDown);
    }
    private void Update()
    {
        _transform.position += Vector3.up * _speed * Time.deltaTime;
    }
}
