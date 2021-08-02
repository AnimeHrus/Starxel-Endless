using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DefaultEnemyMovement : MonoBehaviour
{
    [SerializeField] private float _minPushForce = 1.5f;
    [SerializeField] private float _maxPushForce = 9.5f;
    [SerializeField] private float _minFrequencyMove = 1f;
    [SerializeField] private float _maxFrequencyMove = 3f;
    [SerializeField] private float _magnitudeDifference = 0.5f;
    private Rigidbody2D _rigidBody;
    private float _pushForce;
    private float _frequencyMove;
    private float _minMagnitudeMove;
    private float _maxMagnitudeMove;
    private float _magnitudeMove;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _pushForce = Random.Range(_minPushForce, _maxPushForce);
        _frequencyMove = Random.Range(_minFrequencyMove, _maxFrequencyMove);
        if (_frequencyMove - _magnitudeDifference < _minFrequencyMove)
        {
            _minMagnitudeMove = _minFrequencyMove;
        }
        else
        {
            _minMagnitudeMove = _frequencyMove - _magnitudeDifference;
        }
        _maxMagnitudeMove = _frequencyMove + _minFrequencyMove;
        _magnitudeMove = Random.Range(_minMagnitudeMove, _maxMagnitudeMove);
    }

    private void Start()
    {
        AddFirstPush();
    }

    private void FixedUpdate()
    {
        SinusMove();
    }

    private void AddFirstPush()
    {
        _rigidBody.velocity = -transform.up * _pushForce;
    }

    private void SinusMove()
    {
        _rigidBody.AddForce(new Vector2(Mathf.Sin(-Time.time * _frequencyMove) * _magnitudeMove, 0), ForceMode2D.Force);
    }
}
