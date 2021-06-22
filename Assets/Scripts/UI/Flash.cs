using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Flash : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        PlayFlashAnimation(1);
    }

    public void PlayFlashAnimation(float normalizedTime = 0)
    {
        _animator.Play("Flash", 0, normalizedTime);
    }
}
