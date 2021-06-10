using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private Animator anim;
    private float interval;
    private void Start()
    {
        anim = GetComponent<Animator>();
        interval = anim.GetCurrentAnimatorStateInfo(0).length;
    }
    private void Update()
    {
        if (anim.enabled)
        {
            if(interval > 0)
            {
                interval -= Time.unscaledDeltaTime;
            }
            else
            {
                enabled = false;
                Destroy(gameObject);
            }
        }
    }
}
