using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private Animator _animator;
    private float _animationLength;

    private void Start()
    {
        _animator = _animator == null ? GetComponent<Animator>() : _animator;
        _animationLength = _animator.GetCurrentAnimatorStateInfo(0).length;
    }
    private void Update()
    {
        if (_animator.enabled)
        {
            if(_animationLength > 0)
            {
                _animationLength -= Time.unscaledDeltaTime;
            }
            else
            {
                enabled = false;
                Destroy(gameObject);
            }
        }
    }

    public void StartDestroyAnimation()
    {
        _animator.enabled = true;
    }
}
