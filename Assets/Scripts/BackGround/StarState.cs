using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class StarState : MonoBehaviour
{  
    [SerializeField] private float _velocityFast;
    [SerializeField] private float _velocityNormal;
    [SerializeField] private float _velocitySlow;
    [SerializeField] [Range(0, 1)] private float _alphaFast;
    [SerializeField] [Range(0, 1)] private float _alphaNormal;
    [SerializeField] [Range(0, 1)] private float _alphaSlow;
    [SerializeField] [Range(-10, -15)] private int _orderInLayerFast;
    [SerializeField] [Range(-10, -15)] private int _orderInLayerNormal;
    [SerializeField] [Range(-10, -15)] private int _orderInLayerSlow;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private int _orderInLayer;
    private float _velocity;
    private Color _color;
    private StarStates _starState;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetRandomState();
        SetVariables();
    }

    private void Start()
    {
        SetDownDirectionVelocity();
        SetColorAlpha();
        SetOrderInLayer();
    }

    private void SetRandomState()
    {
        var enumValues = System.Enum.GetValues(typeof(StarStates));
        _starState = (StarStates)Random.Range(0, enumValues.Length);
    }

    private void SetVariables()
    {
        switch (_starState)
        {
            case StarStates.Fast:
                SetVariables(_velocityFast, _alphaFast, _orderInLayerFast);
                break;
            case StarStates.Normal:
                SetVariables(_velocityNormal, _alphaNormal, _orderInLayerNormal);
                break;
            case StarStates.Slow:
                SetVariables(_velocitySlow, _alphaSlow, _orderInLayerSlow);
                break;
        }
    }

    private void SetVariables(float velocity, float alpha, int orderInLayer)
    {
        _velocity = velocity;
        _color = new Color(1, 1, 1, alpha);
        _orderInLayer = orderInLayer;
    }

    private void SetDownDirectionVelocity()
    {
        _rigidBody.velocity = Vector2.down * _velocity;
    }

    private void SetColorAlpha()
    {
        _spriteRenderer.color = _color;
    }

    private void SetOrderInLayer()
    {
        _spriteRenderer.sortingOrder = _orderInLayer;
    }

    private enum StarStates
    {
        Fast,
        Normal,
        Slow
    }
}
