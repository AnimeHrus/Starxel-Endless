using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
[RequireComponent(typeof(Transform))]
public class PlayerGuns : MonoBehaviour
{
    [SerializeField] private GameObject _playerLaser;
    [SerializeField] private Transform[] _gunsPositions;
    private WaitForSeconds _attackIntensity;

    private void Awake()
    {
        _attackIntensity = new WaitForSeconds(0.3f);
    }

    private void Start()
    {
        StartCoroutine(Attack(_playerLaser, _gunsPositions));
    }

    private IEnumerator Attack(GameObject laser, Transform[] positions)
    {
        while (gameObject != null)
        {
            InstantiateLaser(laser, positions);
            yield return _attackIntensity;
        }
    }

    private void InstantiateLaser(GameObject laser, Transform[] positions)
    {
        for (int gun = 0; gun < positions.Length; gun++)
        {
            Instantiate(laser, positions[gun].position, Quaternion.identity);
        }
    }
}
