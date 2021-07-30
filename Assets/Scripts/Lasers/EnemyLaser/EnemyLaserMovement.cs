using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyLaserMovement : MonoBehaviour
{
    [SerializeField]
    private float _velocity;
    [SerializeField]
    private float _frequencyMove;
    [SerializeField]
    private float _magnitudeMove;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        AddVelocity();
        //ChangeAngle();
    }

    private void Update()
    {
        ChangeAngle();
    }

    private void AddVelocity()
    {
        _rigidBody.velocity = transform.up * _velocity;
    }

    private void ChangeAngle()
    {
        //_rigidBody.AddTorque(Mathf.Sin(Time.time * _frequencyMove) * _magnitudeMove, ForceMode2D.Force);
        transform.Rotate(0, 0, Mathf.Sin(Time.time * _frequencyMove) * _magnitudeMove * Time.deltaTime);
    }
}
