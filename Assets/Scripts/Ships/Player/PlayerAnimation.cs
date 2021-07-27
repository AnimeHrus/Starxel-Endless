using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PlayerImmortal.OnImmortalStart += PlayImmortalAnimation;
        PlayerImmortal.OnImmortalEnd += PlayIdleAnimation;
    }

    private void OnDisable()
    {
        PlayerImmortal.OnImmortalStart -= PlayImmortalAnimation;
        PlayerImmortal.OnImmortalEnd -= PlayIdleAnimation;
    }

    private void PlayImmortalAnimation()
    {
        _animator.Play("Immortal");
    }

    private void PlayIdleAnimation()
    {
        _animator.Play("Idle");
    }
}
