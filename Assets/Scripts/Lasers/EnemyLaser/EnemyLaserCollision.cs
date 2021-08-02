using UnityEngine;

public class EnemyLaserCollision : MonoBehaviour
{
    [SerializeField] private GameObject[] _hitFX;
    [SerializeField] private Transform _contactTransform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.ApplyDamage();
            InstantiateHitFX();
            Destroy(gameObject);
        }
    }

    private void InstantiateHitFX()
    {
        Instantiate(_hitFX[GetRandomHitFX()], _contactTransform.position, Quaternion.identity);
    }

    private int GetRandomHitFX()
    {
        return Random.Range(0, _hitFX.Length);
    }
}
