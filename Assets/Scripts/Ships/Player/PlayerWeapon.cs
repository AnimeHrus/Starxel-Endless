using System.Collections;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerLaser;
    [SerializeField]
    private GameObject _shootFX;
    [SerializeField]
    private Transform[] _gunsPositions;
    [SerializeField]
    private float _attackIntensityTime;
    private WaitForSeconds _attackIntensityWait;

    private void Awake()
    {
        _attackIntensityWait = new WaitForSeconds(_attackIntensityTime);
    }

    private void Start()
    {
        StartCoroutine(Attack(_playerLaser, _gunsPositions));
    }

    private IEnumerator Attack(GameObject laser, Transform[] positions)
    {
        while (gameObject != null)
        {
            InstantiateLaser(laser, positions);
            yield return _attackIntensityWait;
        }
    }

    private void InstantiateLaser(GameObject laser, Transform[] positions)
    {
        for (int gun = 0; gun < positions.Length; gun++)
        {
            Instantiate(laser, positions[gun].position, Quaternion.identity);
            InstantiateShootFX(positions[gun]);
        }
    }

    private void InstantiateShootFX(Transform weaponPosition)
    {
        Instantiate(_shootFX, weaponPosition.position, Quaternion.identity, gameObject.transform);
    }
}
