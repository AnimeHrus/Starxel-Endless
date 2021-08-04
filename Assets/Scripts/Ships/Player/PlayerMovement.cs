using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private SpriteRenderer _spriteRenderer;
    private float _spriteYSize;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteYSize = _spriteRenderer.bounds.size.y;
    }

    private void OnEnable()
    {
        TapInput.OnTapToScreen += MoveToTouchPosition;
    }

    private void OnDisable()
    {
        TapInput.OnTapToScreen -= MoveToTouchPosition;
    }

    public void MoveToTouchPosition(Vector3 touchPosition)
    {
        Vector2 direction = new Vector2(touchPosition.x, touchPosition.y + _spriteYSize);
        transform.position = Vector2.MoveTowards(transform.position, direction, _speed * Time.deltaTime);
    }
}
