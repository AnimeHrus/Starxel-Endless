using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
[RequireComponent(typeof(FlashScreen))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerState _playerState;
    [SerializeField] private FlashScreen _flashScreen;
    [SerializeField] private Heart[] _hearts;
    private int _health = 3;

    public void ApplyDamage(int damage = 1)
    {
        if(_playerState.GetCurrentStatus() != "Normal")
        {
            return;
        }

        for(int i = 0; i < damage; i++)
        {
            if(_health > 0)
            {
                _health--;
                _hearts[_health].StartDestroyAnimation();
                _playerState.BecomeImmortal();
                _flashScreen.InstantiateFlashScreen();
                if(_health <= 0)
                {
                    Die();
                    return;
                }
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
