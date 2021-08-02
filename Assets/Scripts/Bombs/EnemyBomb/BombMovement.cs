using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BombMovement : MonoBehaviour
{
    [SerializeField] private float _pushForce;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AddFirstPush();
    }

    private void AddFirstPush()
    {
        _rigidBody.velocity = -transform.up * _pushForce;
    }
}
