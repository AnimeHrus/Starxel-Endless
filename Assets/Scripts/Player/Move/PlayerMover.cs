using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed;

    public Vector2 GetCurrentPosition()
    {
        return _transform.position;
    }

    public void MoveToTouchPosition(Vector2 touchPosition)
    {
        _transform.position = Vector2.MoveTowards(_transform.position, touchPosition, _speed * Time.deltaTime);
    }
}
