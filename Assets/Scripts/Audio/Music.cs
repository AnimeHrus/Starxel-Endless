using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;

    private void Start()
    {
        if (!_musicSource.isPlaying)
        {
            PlayMusicTheme();
        }
    }

    private void PlayMusicTheme()
    {
        _musicSource.Play();
    }
}
