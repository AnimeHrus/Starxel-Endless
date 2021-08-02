using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyLaserMovement : MonoBehaviour
{
    [SerializeField] private float _velocity;
    [SerializeField] private float _frequencyMove;
    [SerializeField] private float _magnitudeMove;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ChangeAngle();
    }

    private void FixedUpdate()
    {
        AddFowardVelocity();
    }

    private void AddFowardVelocity()
    {
        _rigidBody.velocity = transform.up * _velocity;
    }

    private void ChangeAngle()
    {
        transform.Rotate(0, 0, Mathf.Sin(Time.time * _frequencyMove) * _magnitudeMove * Time.deltaTime);
    }
}
