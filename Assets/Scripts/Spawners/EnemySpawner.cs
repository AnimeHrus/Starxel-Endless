using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private GameObject[] _enemies;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private int _FirstWaveCount;
    [SerializeField]
    private float _spawnCoolDown;
    [SerializeField]
    [Range(0, 30)]
    private float _constrictionProcent;
    private WaitForSeconds _spawnWait;
    private Vector2 _spawnPosition;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        _spawnWait = new WaitForSeconds(_spawnCoolDown);
    }

    private void Start()
    {
        SpawnFirstWave();
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

    private void SpawnFirstWave()
    {
        StartCoroutine(InstantiateEnemy(_FirstWaveCount));
    }

    private void SpawnNewEnemy()
    {
        StartCoroutine(InstantiateEnemy());
    }

    private IEnumerator InstantiateEnemy(int enemyCount)
    {
        for (int spawnedEnemy = 0; spawnedEnemy < enemyCount; spawnedEnemy++)
        {
            yield return _spawnWait;
            SetRandomUpperPosition();
            Instantiate(_enemies[GetRandomEnemy()], _spawnPosition, Quaternion.identity);
        }
    }

    private IEnumerator InstantiateEnemy()
    {
        yield return _spawnWait;
        SetRandomUpperPosition();
        Instantiate(_enemies[GetRandomEnemy()], _spawnPosition, Quaternion.identity);
    }

    private int GetRandomEnemy()
    {
        return Random.Range(0, _enemies.Length);
    }

    private void SetRandomUpperPosition()
    {
        _spawnPosition = _camera.ScreenToWorldPoint(new Vector2(Random.Range(0 + GetXConstriction(), _camera.pixelWidth - GetXConstriction()), _camera.pixelHeight));
    }

    private float GetXConstriction()
    {
        return (_constrictionProcent * _camera.pixelWidth) / 100;
    }
}
