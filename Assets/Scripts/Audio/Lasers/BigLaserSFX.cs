using UnityEngine;

public class BigLaserSFX : MonoBehaviour
{
    [SerializeField] private AudioSource _bigLaserSFX;

    private void PlayBigLaserSFX()
    {
        _bigLaserSFX.Play();
    }
}
