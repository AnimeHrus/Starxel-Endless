using UnityEngine;

public class PhoridaeCollision : MonoBehaviour
{
    [SerializeField] private GameObject[] _hits;

    private void OnTriggerStay2D(Collider2D collision)
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
        Instantiate(_hits[GetRandomHitFX()], transform.position, Quaternion.identity);
    }

    private int GetRandomHitFX()
    {
        return Random.Range(0, _hits.Length);
    }
}
