using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private GameObject playerLaser;
    [SerializeField] private Transform leftGunPosition;
    [SerializeField] private Transform rightGunPosition;
    private float speed = 10f;
    private int health = 3;
    private float attackIntensity = 0.3f;

    private void Start()
    {
        StartCoroutine(Attack(playerLaser, leftGunPosition, rightGunPosition));    
    }

    private void Update()
    {
        if (health <= 0) Die();
    }

    public void MoveToTouchPosition(Vector2 touchPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, touchPosition, speed * Time.deltaTime);
    }

    public void ApplyDamage(int damage = 1)
    {
        health -= damage;
    }

    private IEnumerator Attack(GameObject laser, Transform leftPosition, Transform rightPosition)
    {
        InstantiateLaser(laser, leftPosition);
        InstantiateLaser(laser, rightPosition);
        yield return new WaitForSeconds(attackIntensity);
        StartCoroutine(Attack(playerLaser, leftGunPosition, rightGunPosition));
    }

    private void InstantiateLaser(GameObject laser, Transform position)
    {
        Instantiate(laser, position.position, Quaternion.identity);
    }

    private void Die()
    {
        Time.timeScale = 0;
    }
}
