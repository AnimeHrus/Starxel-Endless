using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerLaserMovement : MonoBehaviour
{
    [SerializeField] private float _velocity;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AddUpDirectionVelocity();
    }

    private void AddUpDirectionVelocity()
    {
        _rigidBody.velocity = Vector2.up * _velocity;
    }
}
