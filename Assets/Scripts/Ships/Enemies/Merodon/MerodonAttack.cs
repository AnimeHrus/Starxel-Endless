using System.Collections;
using UnityEngine;

public class MerodonAttack : MonoBehaviour
{
    [SerializeField]
    private Transform _weaponTransform;
    [SerializeField]
    private GameObject _bigLaser;
    [SerializeField]
    private float _attackCoolDown;
    private WaitForSeconds _attackWait;

    private void Awake()
    {
        _attackWait = new WaitForSeconds(_attackCoolDown);
    }

    private void Start()
    {
        StartCoroutine(AttackBigLaser());
    }

    private IEnumerator AttackBigLaser()
    {
        while (gameObject != null)
        {
            InstantiateBigLaser();
            yield return _attackWait;
        }
    }

    private void InstantiateBigLaser()
    {
        Instantiate(_bigLaser, _weaponTransform.position, Quaternion.identity, gameObject.transform);
    }
}
