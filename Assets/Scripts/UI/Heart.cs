using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Heart : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void StartDestroyAnimation()
    {
        _animator.enabled = true;
    }
}
