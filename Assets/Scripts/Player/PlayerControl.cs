using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Movement
    private float speed = 10.0f;
    private Vector2 touchPosition;
    //Shooting
    private float intensity = 0.3f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject leftGun;
    [SerializeField] private GameObject rightGun;
    //Health
    private byte health = 3;
    [SerializeField] private GameObject[] hearts;
    //Unvulnerable
    private bool isDamage = false;
    private float unvulnerableTime = 3.0f;
    [SerializeField] private GameObject flash;
    private Animator flashAnim;
    //Animations
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        flashAnim = flash.GetComponent<Animator>();
        flashAnim.Play("Flash", 0, 1.0f);
        //Shoot
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        //Get touch position
        GetTouchPosition();
    }
    private void FixedUpdate()
    {
        //Touch movement
        MoveTo(touchPosition);
        //Death
        if (health == 0) Death();
    }

    private void GetTouchPosition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        }
        else touchPosition = transform.position;
    }
    private void MoveTo(Vector2 direction)
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
    }
    private IEnumerator Shoot()
    {
        Instantiate(bullet, leftGun.transform.position, Quaternion.identity);
        Instantiate(bullet, rightGun.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(intensity);
        StartCoroutine(Shoot());
    }
    public void TakeDamage()
    {
        if (!isDamage)
        {
            isDamage = true;
            flashAnim.Play("Flash", 0, 0.0f);
            if (health >= 1)
            {
                health--;
                hearts[health].GetComponent<Animator>().enabled = true;
                StartCoroutine(SetUnvulnerable());
            }
        }
    }
    private void Death()
    {
        Destroy(gameObject);
        Time.timeScale = 0f;
    }
    private IEnumerator SetUnvulnerable()
    {
        anim.SetBool("isDamage", true);
        yield return new WaitForSeconds(unvulnerableTime);
        anim.SetBool("isDamage", false);
        isDamage = false;
    }
}
