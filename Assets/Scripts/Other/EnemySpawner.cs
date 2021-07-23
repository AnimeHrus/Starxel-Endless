using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    [SerializeField]
    private GameObject[] _enemies;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private float _spawnPositionY;
    [SerializeField]
    private float _spawnPositionX;
    [SerializeField]
    private int _enemyStartCount;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SpawnFirstWave();
    }

    private void OnEnable()
    {
        EnemyHealth.OnEnemyKilled += InstantiateEnemy;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyKilled -= InstantiateEnemy;
    }

    private void SpawnFirstWave()
    {
        for (int enemySpawned = 0; enemySpawned < _enemyStartCount; enemySpawned++)
        {
            InstantiateEnemy();
        }
    }

    private void InstantiateEnemy()
    {
        int enemyID = Random.Range(0, _enemies.Length);
        Vector2 spawnPosition = new Vector2(Random.Range(-_spawnPositionX, _spawnPositionX), _spawnPositionY);
        Instantiate(_enemies[enemyID], spawnPosition, Quaternion.identity);
    }

    public GameObject GetPlayerObject()
    {
        return _player;
    }
}
