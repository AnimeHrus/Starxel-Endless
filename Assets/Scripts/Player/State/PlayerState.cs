using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
public class PlayerState : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private float immortalCoolDown;
    private PlayerStatus _playerStatus = PlayerStatus.Normal;

    public string GetCurrentStatus()
    {
        return _playerStatus.ToString();
    }

    public void BecomeImmortal()
    {
        StartCoroutine(SetTemporaryImmortalStatus());
    }

    private IEnumerator SetTemporaryImmortalStatus()
    {
        _playerStatus = PlayerStatus.Immortal;
        _playerAnimation.PlayImmortalAnimation();
        yield return new WaitForSeconds(immortalCoolDown);
        _playerStatus = PlayerStatus.Normal;
        _playerAnimation.PlayIdleAnimation();
    }

    private enum PlayerStatus
    {
        Normal,
        Immortal
    }
}
