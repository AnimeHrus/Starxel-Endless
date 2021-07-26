using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
