using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MerodonMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidBody;
    [SerializeField]
    private float _pushForce;
    [SerializeField]
    private float _amplitudeMove;
    [SerializeField]
    private float _frequencyMove;

    private void Start()
    {
        AddFirstPush();
    }

    private void FixedUpdate()
    {
        CosinusMove();
    }

    private void AddFirstPush()
    {
        _rigidBody.velocity = -transform.up * _pushForce;
    }

    private void CosinusMove()
    {
        _rigidBody.AddForce(new Vector2(Mathf.Cos(Time.time * _amplitudeMove) * _frequencyMove, 0), ForceMode2D.Force);
    }
}
