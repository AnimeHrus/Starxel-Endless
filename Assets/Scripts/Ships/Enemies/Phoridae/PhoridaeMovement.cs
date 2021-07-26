using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhoridaeMovement : MonoBehaviour
{
    [SerializeField]
    private float _velocity;
    private Rigidbody2D _rigidBody;
    private Transform _playerTransform;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerTransform = EnemySpawner.Instance.GetPlayerObject().transform;
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
