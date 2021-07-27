using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionFX;
    private int _health = 3;
    private bool _canTakeDamage = true;
    public delegate void HealthChange(int health);
    public static HealthChange OnHealthChanged;
    public delegate void DamageTake();
    public static DamageTake OnDamageTaked;
    public delegate void Killed();
    public static Killed OnBeKilled;

    private void OnEnable()
    {
        PlayerImmortal.OnImmortalStart += DenyDamage;
        PlayerImmortal.OnImmortalEnd += AllowDamage;
    }

    private void OnDisable()
    {
        PlayerImmortal.OnImmortalStart -= DenyDamage;
        PlayerImmortal.OnImmortalEnd -= AllowDamage;
    }

    public void ApplyDamage()
    {
        if (_canTakeDamage)
        {
            _health--;
            OnHealthChanged?.Invoke(_health);
            OnDamageTaked?.Invoke();
            CheckToDie();
        }
    }

    private void DenyDamage()
    {
        _canTakeDamage = false;
    }

    private void AllowDamage()
    {
        _canTakeDamage = true;
    }

    private void CheckToDie()
    {
        if (_health == 0)
        {
            OnBeKilled?.Invoke();
            InstantiateExplosionFX();
            Destroy(gameObject);
        }
    }

    private void InstantiateExplosionFX()
    {
        Instantiate(_explosionFX, transform.position, Quaternion.identity);
    }
}
