using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
