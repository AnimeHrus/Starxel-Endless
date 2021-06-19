using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerShip playerShip;

    private void Start()
    {
        playerShip = playerShip == null ? GetComponent<PlayerShip>() : playerShip;
        if(playerShip == null)
        {
            Debug.LogError("Player not set to controller");
        }
    }

    private void Update()
    {
        if(playerShip != null)
        {
            playerShip.MoveToTouchPosition(GetTouchPosition());
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
            return playerShip.transform.position;
        }
    }
}
