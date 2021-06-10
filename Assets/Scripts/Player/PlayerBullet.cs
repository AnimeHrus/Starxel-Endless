using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //Movement
    private float speed = 20.0f;
    //Destroying
    private float backTime = 3.0f;

    private void Start()
    {
        //Start self destroy
        Destroy(gameObject, backTime);
    }
    private void FixedUpdate()
    {
        //Move to up
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
