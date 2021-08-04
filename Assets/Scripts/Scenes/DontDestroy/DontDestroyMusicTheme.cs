using UnityEngine;

public class DontDestroyMusicTheme : MonoBehaviour
{
    private void Awake()
    {
        int numMusicTheme = FindObjectsOfType<DontDestroyMusicTheme>().Length;
        if (numMusicTheme != 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}