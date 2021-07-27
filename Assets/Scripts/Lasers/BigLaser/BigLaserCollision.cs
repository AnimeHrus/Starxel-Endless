using UnityEngine;

public class BigLaserCollision : MonoBehaviour
{
    private bool _canDoDamage = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_canDoDamage && collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.ApplyDamage();
        }
    }

    private void AllowDoDamage()
    {
        _canDoDamage = true;
    }
}
