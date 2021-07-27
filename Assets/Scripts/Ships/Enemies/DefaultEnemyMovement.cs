using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DefaultEnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private const float _minPushForce = 1.5f;
    private const float _maxPushForce = 9.5f;
    private float _pushForce;
    private const float _minAmplitudeMove = 1f;
    private const float _maxAmplitudeMove = 3f;
    private float _amplitudeMove;
    private const float _frequencyDifference = 0.5f;
    private float _minFrequencyMove;
    private float _maxFrequencyMove;
    private float _frequencyMove;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _pushForce = Random.Range(_minPushForce, _maxPushForce);
        _amplitudeMove = Random.Range(_minAmplitudeMove, _maxAmplitudeMove);
        if (_amplitudeMove - _frequencyDifference < _minAmplitudeMove)
        {
            _minFrequencyMove = _minAmplitudeMove;
        }
        else
        {
            _minFrequencyMove = _amplitudeMove - _frequencyDifference;
        }
        _maxFrequencyMove = _amplitudeMove + _minAmplitudeMove;
        _frequencyMove = Random.Range(_minFrequencyMove, _maxFrequencyMove);
    }

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
