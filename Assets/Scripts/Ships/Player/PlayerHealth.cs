using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _health = 3;
    public delegate void HealthChange(int health);
    public static HealthChange OnHealthChanged;
    public delegate void DamageTake();
    public static DamageTake OnDamageTaked;
    public delegate void Killed();
    public static Killed OnBeKilled;

    public void ApplyDamage()
    {
        _health--;
        OnHealthChanged?.Invoke(_health);
        OnDamageTaked?.Invoke();
        CheckToDie();
    }

    private void CheckToDie()
    {
        if (_health <= 0)
        {
            OnBeKilled?.Invoke();
            Destroy(gameObject);
        }
    }
}
