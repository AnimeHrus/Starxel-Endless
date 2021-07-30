using UnityEngine;

public class PlayerWrap : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    private SpriteRenderer _spriteRenderer;
    private float _spriteXSize;
    private float _spriteYSize;
    private Vector2 _cameraMaxWorldPoint;
    private Vector2 _cameraMinWorldPoint;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteXSize = _spriteRenderer.sprite.bounds.size.x * 0.5f;
        _spriteYSize = _spriteRenderer.sprite.bounds.size.y * 0.5f;
        _cameraMaxWorldPoint = _camera.ScreenToWorldPoint(new Vector2(_camera.pixelWidth, _camera.pixelHeight));
        _cameraMinWorldPoint = _camera.ScreenToWorldPoint(new Vector2(0, 0));
    }

    private void Update()
    {
        if (transform.position.x + _spriteXSize < _cameraMinWorldPoint.x)
        {
            transform.position = new Vector2(_cameraMaxWorldPoint.x, transform.position.y);
        }
        else if (transform.position.y + _spriteYSize < _cameraMinWorldPoint.y)
        {
            transform.position = new Vector2(transform.position.x, _cameraMaxWorldPoint.y);
        }
        else if (transform.position.x - _spriteXSize > _cameraMaxWorldPoint.x)
        {
            transform.position = new Vector2(_cameraMinWorldPoint.x, transform.position.y);
        }
        else if (transform.position.y - _spriteYSize > _cameraMaxWorldPoint.y)
        {
            transform.position = new Vector2(transform.position.x, _cameraMinWorldPoint.y);
        }
    }
}
