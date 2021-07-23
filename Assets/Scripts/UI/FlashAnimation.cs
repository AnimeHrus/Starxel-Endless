using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FlashAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private void OnEnable()
    {
        PlayerHealth.OnDamageTaked += PlayFlashAnimation;
    }

    private void OnDisable()
    {
        PlayerHealth.OnDamageTaked -= PlayFlashAnimation;
    }

    private void PlayIdleAnimation()
    {
        _animator.Play("Idle");
    }

    private void PlayFlashAnimation()
    {
        _animator.Play("Flash");
    }
}
