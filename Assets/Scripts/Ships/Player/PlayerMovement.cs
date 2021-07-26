using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _velocity;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void MoveToTouchPosition(Vector3 touchPosition)
    {

        Vector3 direction = touchPosition - transform.position;
        _rigidBody.velocity = direction * _velocity;
    }

    private void OnEnable()
    {
        TapInput.OnTapToScreen += MoveToTouchPosition;
    }

    private void OnDisable()
    {
        TapInput.OnTapToScreen -= MoveToTouchPosition;
    }
}
