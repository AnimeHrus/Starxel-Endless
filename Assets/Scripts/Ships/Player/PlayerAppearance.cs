using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _velocity;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private float _spriteXSize;
    private Vector2 _cameraZeroPoint;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteXSize = _spriteRenderer.sprite.bounds.size.x * 0.5f;
        _cameraZeroPoint = _camera.ScreenToWorldPoint(new Vector2(0, 0));
    }

    private void Start()
    {
        SetToStartPosition();
        Push();
    }

    private void SetToStartPosition()
    {
        transform.position = new Vector2(transform.position.x, _cameraZeroPoint.y - _spriteXSize);
    }

    private void Push()
    {
        _rigidBody.velocity = Vector2.up * _velocity;
    }
}
