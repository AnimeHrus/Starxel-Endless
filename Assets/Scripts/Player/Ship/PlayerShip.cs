using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Transform))]
public class PlayerShip : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _transform;
    [SerializeField] private Heart[] _hearts;
    [SerializeField] private Flash _flash;
    private const float _speed = 10f;
    private int _health = 3;
    private ShipState _shipState = ShipState.Normal;
    private float immortalCoolDown = 3f;

    public Vector2 GetCurrentPosition()
    {
        return _transform.position;
    }

    public void MoveToTouchPosition(Vector2 touchPosition)
    {
        _transform.position = Vector2.MoveTowards(_transform.position, touchPosition, _speed * Time.deltaTime);
    }

    public void ApplyDamage(int damage = 1)
    {
        if (_shipState != ShipState.Normal) return;
        StartCoroutine(BecomeImmortal());
        _flash.PlayFlashAnimation();
        if (_health > 0)
        {
            _health -= damage;
            _hearts[_health].StartDestroyAnimation();
        }
        if (_health <= 0)
        {
            Die();
        }
    }

    private IEnumerator BecomeImmortal()
    {
        _shipState = ShipState.Immortal;
        _animator.Play("Immortal");
        yield return new WaitForSeconds(immortalCoolDown);
        _shipState = ShipState.Normal;
        _animator.Play("Idle");
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    enum ShipState
    {
        Normal,
        Immortal
    }
}
