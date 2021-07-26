using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int _health;
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;

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
            Destroy(gameObject);
        }
    }
}
