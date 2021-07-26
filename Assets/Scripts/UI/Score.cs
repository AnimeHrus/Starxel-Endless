using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    [SerializeField]
    private string _scoreStartText;
    private Text _text;
    private int _scoreCount = 0;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        EnemyHealth.OnEnemyKilled += AddScore;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyKilled -= AddScore;
    }

    private void AddScore()
    {
        _scoreCount++;
        _text.text = _scoreStartText + " " + _scoreCount.ToString();
    }
}
