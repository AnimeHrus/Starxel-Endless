using UnityEngine;

public class PhoridaeMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidBody;
    [SerializeField]
    private float _velocity;
    private Transform _playerTransform;

    private void Awake()
    {
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
