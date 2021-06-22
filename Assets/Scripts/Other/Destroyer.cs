using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public void DestroyGameObject(float timeCoolDown = 0)
    {
        Destroy(gameObject, timeCoolDown);
    }
}
