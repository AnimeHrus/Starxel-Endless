using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class StarState : MonoBehaviour
{  
    [SerializeField]
    private float _velocityFast;
    [SerializeField]
    private float _velocityNormal;
    [SerializeField]
    private float _velocitySlow;
    [SerializeField]
    [Range(0, 1)]
    private float _alphaFast;
    [SerializeField]
    [Range(0, 1)]
    private float _alphaNormal;
    [SerializeField]
    [Range(0, 1)]
    private float _alphaSlow;
    [SerializeField]
    [Range(-10, -15)]
    private int _orderInLayerFast;
    [SerializeField]
    [Range(-10, -15)]
    private int _orderInLayerNormal;
    [SerializeField]
    [Range(-10, -15)]
    private int _orderInLayerSlow;
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
    }

    private void Start()
    {
        SetVelocity();
        SetColorAlpha();
        SetOrderInLayer();
    }

    private void SetRandomState()
    {
        var enumValues = System.Enum.GetValues(typeof(StarStates));
        _starState = (StarStates)Random.Range(0, enumValues.Length);
        SetVariables();
    }

    private void SetVariables()
    {
        switch (_starState)
        {
            case StarStates.Fast:
                SetFastStateVariables();
                break;
            case StarStates.Normal:
                SetNormalStateVariables();
                break;
            case StarStates.Slow:
                SetSlowStateVariables();
                break;
        }
    }

    private void SetFastStateVariables()
    {
        _velocity = _velocityFast;
        _color = new Color(1, 1, 1, _alphaFast);
        _orderInLayer = _orderInLayerFast;
    }

    private void SetNormalStateVariables()
    {
        _velocity = _velocityNormal;
        _color = new Color(1, 1, 1, _alphaNormal);
        _orderInLayer = _orderInLayerNormal;
    }

    private void SetSlowStateVariables()
    {
        _velocity = _velocitySlow;
        _color = new Color(1, 1, 1, _alphaSlow);
        _orderInLayer = _orderInLayerSlow;
    }

    private void SetVelocity()
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
