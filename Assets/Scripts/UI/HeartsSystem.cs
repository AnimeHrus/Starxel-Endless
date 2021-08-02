using UnityEngine;

public class HeartsSystem : MonoBehaviour
{
    [SerializeField] private Animator[] _heartAnimators;
    [SerializeField] private string _heartAnimationName;

    private void OnEnable()
    {
        PlayerHealth.OnHealthChanged += PlayAnimationDestroyHeart;
    }

    private void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= PlayAnimationDestroyHeart;
    }

    private void PlayAnimationDestroyHeart(int health)
    {
        _heartAnimators[health].Play(_heartAnimationName);
    }
}
