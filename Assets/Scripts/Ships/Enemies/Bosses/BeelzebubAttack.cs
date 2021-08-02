using System.Collections;
using UnityEngine;

public class BeelzebubAttack : MonoBehaviour
{
    [SerializeField] private Transform[] _laserWeapons;
    [SerializeField] private Transform[] _bombWeapons;
    [SerializeField] private GameObject _bigLaser;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private float _laserAttackCoolDown;
    [SerializeField] private float _bombAttackCoolDown;
    private WaitForSeconds _laserAttackWait;
    private WaitForSeconds _bombAttackWait;
    private Transform _playerTransform;

    private void Awake()
    {
        _laserAttackWait = new WaitForSeconds(_laserAttackCoolDown);
        _bombAttackWait = new WaitForSeconds(_bombAttackCoolDown);
        _playerTransform = EnemySpawner.Instance.GetPlayerObject().transform;
    }

    private void Start()
    {
        StartCoroutine(AttackBomb());
        StartCoroutine(AttackLaser());
    }

    private IEnumerator AttackBomb()
    {
        while (gameObject != null)
        {
            yield return _bombAttackWait;
            if (_playerTransform != null)
            {
                InstantiateBomb();
            }
        }
    }

    private IEnumerator AttackLaser()
    {
        while (gameObject != null)
        {
            yield return _laserAttackWait;
            if(_playerTransform != null)
            {
                RotateLaserWeapon();
                InstantiateLaser();
            }
        }
    }

    private void InstantiateBomb()
    {
        Instantiate(_bomb, _bombWeapons[GetRandomWeapon(_bombWeapons)].position, Quaternion.identity);
    }

    private void InstantiateLaser()
    {
        for (int spawnedLaser = 0; spawnedLaser < _laserWeapons.Length; spawnedLaser++)
        {
            Instantiate(_bigLaser, _laserWeapons[spawnedLaser].position, _laserWeapons[spawnedLaser].rotation, _laserWeapons[spawnedLaser]);
        }
    }

    private int GetRandomWeapon(Transform[] weapons)
    {
        return Random.Range(0, weapons.Length);
    }

    private void RotateLaserWeapon()
    {
        if (_playerTransform != null)
        {
            for (int rotatedLaserWeapon = 0; rotatedLaserWeapon < _laserWeapons.Length; rotatedLaserWeapon++)
            {
                _playerTransform = EnemySpawner.Instance.GetPlayerObject().transform;
                Vector3 direction = (_playerTransform.position - _laserWeapons[rotatedLaserWeapon].position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                _laserWeapons[rotatedLaserWeapon].rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            }
        }
    }
}
