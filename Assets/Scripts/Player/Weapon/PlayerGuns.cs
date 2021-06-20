using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    [SerializeField] private GameObject _playerLaser;
    [SerializeField] private Transform _leftGunPosition;
    [SerializeField] private Transform _rightGunPosition;
    private float _attackIntensity = 0.3f;

    private void Start()
    {
        StartCoroutine(Attack(_playerLaser, _leftGunPosition, _rightGunPosition));
    }

    private IEnumerator Attack(GameObject laser, Transform leftPosition, Transform rightPosition)
    {
        InstantiateLaser(laser, leftPosition);
        InstantiateLaser(laser, rightPosition);
        yield return new WaitForSeconds(_attackIntensity);
        StartCoroutine(Attack(_playerLaser, _leftGunPosition, _rightGunPosition));
    }

    private void InstantiateLaser(GameObject laser, Transform position)
    {
        Instantiate(laser, position.position, Quaternion.identity);
    }
}
