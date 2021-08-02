using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private GameObject _boss;
    [SerializeField] private GameObject _player;
    [SerializeField] private int _FirstWaveCount;
    [SerializeField] private int _enemyKillForBoss;
    [SerializeField] private float _spawnCoolDown;
    [SerializeField] private float _spawnBossCoolDown;
    [SerializeField] [Range(0, 30)] private float _constrictionProcent;
    private WaitForSeconds _spawnWait;
    private WaitForSeconds _spawnBossWait;
    private Vector2 _spawnPosition;
    private int _allSpawnedEnemy = 0;
    private int _currentEnemy = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        _spawnWait = new WaitForSeconds(_spawnCoolDown);
        _spawnBossWait = new WaitForSeconds(_spawnBossCoolDown);
    }

    private void Start()
    {
        SpawnWave();
    }

    private void OnEnable()
    {
        EnemyHealth.OnEnemyKilled += SpawnNewEnemy;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyKilled -= SpawnNewEnemy;
    }

    public GameObject GetPlayerObject()
    {
        return _player;
    }

    private void SpawnWave()
    {
        StartCoroutine(InstantiateEnemy(_FirstWaveCount));
    }

    private void SpawnNewEnemy()
    {
        _currentEnemy--;
        if (_currentEnemy == 0 && _allSpawnedEnemy == 0)
        {
            SpawnWave();
        }
        else if (_currentEnemy == 0 && _allSpawnedEnemy == _enemyKillForBoss)
        {
            SpawnBoss();
        }
        else if (_allSpawnedEnemy < _enemyKillForBoss)
        {
            StartCoroutine(InstantiateEnemy());
        }
    }

    private void SpawnBoss()
    {
        StartCoroutine(InstantiateBoss());
    }

    private IEnumerator InstantiateEnemy(int enemyCount)
    {
        for (int spawnedEnemy = 0; spawnedEnemy < enemyCount; spawnedEnemy++)
        {
            yield return _spawnWait;
            SetRandomUpperPosition();
            Instantiate(_enemies[GetRandomEnemy()], _spawnPosition, Quaternion.identity);
            _allSpawnedEnemy++;
            _currentEnemy++;
        }
    }

    private IEnumerator InstantiateEnemy()
    {
        yield return _spawnWait;
        SetRandomUpperPosition();
        if (_player != null)
        {
            Instantiate(_enemies[GetRandomEnemy()], _spawnPosition, Quaternion.identity);
            _allSpawnedEnemy++;
            _currentEnemy++;
        }
    }

    private IEnumerator InstantiateBoss()
    {
        yield return _spawnBossWait;
        SetCenterUpperPosition();
        if (_player != null)
        {
            Instantiate(_boss, _spawnPosition, Quaternion.identity);
            _FirstWaveCount++;
            _currentEnemy++;
            _allSpawnedEnemy = 0;
        }
    }

    private int GetRandomEnemy()
    {
        return Random.Range(0, _enemies.Length);
    }

    private void SetRandomUpperPosition()
    {
        _spawnPosition = _camera.ScreenToWorldPoint(new Vector2(Random.Range(0 + GetXConstriction(), _camera.pixelWidth - GetXConstriction()), _camera.pixelHeight));
    }

    private void SetCenterUpperPosition()
    {
        _spawnPosition = _camera.ScreenToWorldPoint( new Vector2(_camera.pixelWidth * 0.5f, _camera.pixelHeight));
    }

    private float GetXConstriction()
    {
        return (_constrictionProcent * _camera.pixelWidth) / 100;
    }
}
