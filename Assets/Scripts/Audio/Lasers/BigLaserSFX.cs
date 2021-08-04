using UnityEngine;

public class BigLaserSFX : MonoBehaviour
{
    [SerializeField] private AudioSource _bigLaserSFX;
    [SerializeField] private AudioClip _bigLaserLoadingClip;
    [SerializeField] private AudioClip _bigLaserShootClip;

    private void PlayBigLaserLoading()
    {
        _bigLaserSFX.clip = _bigLaserLoadingClip;
        _bigLaserSFX.Play();
    }

    private void PlayBigLaserShoot()
    {
        _bigLaserSFX.clip = _bigLaserShootClip;
        _bigLaserSFX.Play();
    }

    
}
