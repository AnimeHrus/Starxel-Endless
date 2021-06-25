using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScreen : MonoBehaviour
{
    [SerializeField] private GameObject _flash;
    [SerializeField] private GameObject _canvas;

    public void InstantiateFlashScreen()
    {
        Instantiate(_flash, _canvas.transform.position, Quaternion.identity, _canvas.transform);
    }
}
