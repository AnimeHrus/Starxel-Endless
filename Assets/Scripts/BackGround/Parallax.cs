using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Parallax : MonoBehaviour
{
    [SerializeField]
    private float _parallaxEffect;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _startPosition;
    private float _endPositionY;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startPosition = new Vector2 (transform.position.x, transform.position.y);
        _endPositionY = -_spriteRenderer.bounds.size.y;
    }

    private void Start()
    {
        SetVelocity();
    }

    private void FixedUpdate()
    {
        if (transform.position.y < _endPositionY)
        {
            transform.position = _startPosition;
        }
    }

    private void SetVelocity()
    {
        _rigidBody.velocity = Vector2.down * _parallaxEffect;
    }
}
