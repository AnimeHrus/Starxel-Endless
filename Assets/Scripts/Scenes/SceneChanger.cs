using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private float _restartCoolDown;
    private WaitForSeconds _restartWait;

    private void Awake()
    {
        _restartWait = new WaitForSeconds(_restartCoolDown);
    }

    private void OnEnable()
    {
        PlayerHealth.OnBeKilled += LoadTeamScene;
    }

    private void OnDisable()
    {
        PlayerHealth.OnBeKilled -= LoadTeamScene;
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadTeamScene()
    {
        StartCoroutine(LoadingTeamScene());
    }

    private IEnumerator LoadingTeamScene()
    {
        yield return _restartWait;
        SceneManager.LoadScene(0);
    }
}
