using System.Collections;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] private GameObject _laser;
    [SerializeField] private int _minLaser;
    [SerializeField] private int _maxLaser;
    [SerializeField] private GameObject _explosionFX;
    [SerializeField] private float _timer;
    private WaitForSeconds _timerWait;

    private void Awake()
    {
        _timerWait = new WaitForSeconds(_timer);
    }

    private void Start()
    {
        StartCoroutine(InstantiateEnemyLasers());
    }

    private IEnumerator InstantiateEnemyLasers()
    {
        yield return _timerWait;
        InstantiateExplosionFX();
        InstantiateLasers();
        Destroy(gameObject);
    }

    private void InstantiateExplosionFX()
    {
        Instantiate(_explosionFX, transform.position, Quaternion.identity);
    }

    private void InstantiateLasers()
    {
        int needLasers = GetRandomLaserCount();
        for (int spawnedLaser = 0; spawnedLaser < needLasers; spawnedLaser++)
        {
            Instantiate(_laser, transform.position, Quaternion.Euler(0, 0, GetRandomAngle()));
        }
    }

    private int GetRandomLaserCount()
    {
        return Random.Range(_minLaser, _maxLaser + 1);
    }

    private float GetRandomAngle()
    {
        return Random.Range(0f, 360f);
    }
}
