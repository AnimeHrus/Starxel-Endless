using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerShip))]
[RequireComponent(typeof(Camera))]
public class PlayerTapInput : MonoBehaviour
{
    [SerializeField] private PlayerShip _playerShip;
    [SerializeField] private Camera _camera;

    private void Update()
    {
        _playerShip.MoveToTouchPosition(GetTouchPosition());
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
            return _playerShip.GetCurrentPosition();
        }
    }
}
