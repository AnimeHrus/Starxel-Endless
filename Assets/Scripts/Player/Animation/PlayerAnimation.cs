using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlayImmortalAnimation()
    {
        _animator.Play("Immortal");
    }

    public void PlayIdleAnimation()
    {
        _animator.Play("Idle");
    }
}
