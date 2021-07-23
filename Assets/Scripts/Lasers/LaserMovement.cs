using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LaserMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidBody;
    [SerializeField]
    private float _velocity;

    private void Start()
    {
        AddVelocity();
    }

    private void AddVelocity()
    {
        _rigidBody.velocity = transform.up * _velocity;
    }
}
