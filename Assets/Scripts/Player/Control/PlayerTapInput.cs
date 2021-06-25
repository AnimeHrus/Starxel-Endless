using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerTapInput : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Camera _camera;

    private void Update()
    {
        _playerMover.MoveToTouchPosition(GetTouchPosition());
    }

    private Vector2 GetTouchPosition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return _camera.ScreenToWorldPoint(touch.position);
        }
        else
        {
            return _playerMover.GetCurrentPosition();
        }
    }
}
