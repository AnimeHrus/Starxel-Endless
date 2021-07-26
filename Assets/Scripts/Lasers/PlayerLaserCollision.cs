using UnityEngine;

public class PlayerLaserCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.ApplyDamage();
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
