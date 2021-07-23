using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private void PlayImmortalAnimation()
    {
        _animator.Play("Immortal");
    }

    private void PlayIdleAnimation()
    {
        _animator.Play("Idle");
    }
}
