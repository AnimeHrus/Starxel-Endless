using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerShip _playerShip;

    private void Start()
    {
        _playerShip = _playerShip == null ? GetComponent<PlayerShip>() : _playerShip;
        if (_playerShip == null)
        {
            Debug.LogError("Player not set to controller");
        }
    }

    private void Update()
    {
        if(_playerShip != null)
        {
            _playerShip.MoveToTouchPosition(GetTouchPosition());
        }
    }

    private Vector2 GetTouchPosition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return Camera.main.ScreenToWorldPoint(touch.position);
        }
        else
        {
            return _playerShip.GetTransformPosition();
        }
    }
}
