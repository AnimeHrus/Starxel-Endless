using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _scoreValue;
    [SerializeField]
    private GameObject _explosionFX;
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    public delegate void EnemyScore(int value);
    public static event EnemyScore OnEnemyAddedScore;

    public void ApplyDamage()
    {
        _health--;
        CheckToDie();
    }

    private void CheckToDie()
    {
        if (_health == 0)
        {
            OnEnemyKilled?.Invoke();
            OnEnemyAddedScore?.Invoke(_scoreValue);
            InstantiateExplosionFX();
            Destroy(gameObject);
        }
    }

    private void InstantiateExplosionFX()
    {
        Instantiate(_explosionFX, transform.position, Quaternion.identity);
    }
}
