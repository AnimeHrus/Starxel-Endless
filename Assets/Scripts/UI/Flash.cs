using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = _animator == null ? GetComponent<Animator>() : _animator;
        _animator.Play("Flash", 0, 1);
    }

    public void PlayFlashAnimation()
    {
        _animator.Play("Flash", 0, 0);
    }
}
