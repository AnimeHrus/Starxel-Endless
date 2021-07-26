using System.Collections;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private GameObject _star;
    [SerializeField]
    private int _firstStarsCount;
    [SerializeField]
    private float _spawnCoolDown;
    private WaitForSeconds _spawnWait;
    private Vector2 _spawnPosition;

    private void Awake()
    {
        _spawnWait = new WaitForSeconds(_spawnCoolDown);
    }

    private void Start()
    {
        InstantiateFirstStars();
    }

    private void InstantiateFirstStars()
    {
        for (int spawnedStar = 0; spawnedStar < _firstStarsCount; spawnedStar++)
        {
            SetRandomPosition();
            Instantiate(_star, _spawnPosition, Quaternion.identity);
        }
        StartCoroutine(InstantiateStar());
    }

    private IEnumerator InstantiateStar()
    {
        while (gameObject != null)
        {
            SetRandomUpperPosition();
            Instantiate(_star, _spawnPosition, Quaternion.identity);
            yield return _spawnWait;
        }
    }

    private void SetRandomUpperPosition()
    {
        _spawnPosition = _camera.ScreenToWorldPoint(new Vector2(Random.Range(0, _camera.pixelWidth), _camera.pixelHeight));
    }

    private void SetRandomPosition()
    {
        _spawnPosition = _camera.ScreenToWorldPoint(new Vector2(Random.Range(0, _camera.pixelWidth), Random.Range(0, _camera.pixelHeight)));
    }
}
