using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhoridaeMovement : MonoBehaviour
{
    private const float _minVelocity = 0.1f;
    private const float _maxVelocity = 0.4f;
    private float _velocity;
    private Rigidbody2D _rigidBody;
    private Transform _playerTransform;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerTransform = EnemySpawner.Instance.GetPlayerObject().transform;
        _velocity = Random.Range(_minVelocity, _maxVelocity);
    }

    private void FixedUpdate()
    {
        if (_playerTransform != null)
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        Vector3 direction = _playerTransform.position - transform.position;
        _rigidBody.velocity = direction * _velocity;
    }
}
