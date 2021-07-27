using System.Collections;
using UnityEngine;

public class CalliphoridaeAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject _bomb;
    [SerializeField]
    private Transform _weaponTransform;
    [SerializeField]
    private GameObject _shootFX;
    [SerializeField]
    private float _attackCoolDown;
    private WaitForSeconds _attackWait;
    private Vector3 _shootFXQuaternion;

    private void Awake()
    {
        _attackWait = new WaitForSeconds(_attackCoolDown);
        _shootFXQuaternion = new Vector3(0f, 0f, 180f);
    }

    private void Start()
    {
        StartCoroutine(AttackBomb());
    }

    private IEnumerator AttackBomb()
    {
        while (gameObject != null)
        {
            InstantiateBomb();
            InstantiateShootFX();
            yield return _attackWait;
        }
    }

    private void InstantiateBomb()
    {
        Instantiate(_bomb, _weaponTransform.position, Quaternion.identity);
    }

    private void InstantiateShootFX()
    {
        Instantiate(_shootFX, _weaponTransform.position, Quaternion.Euler(_shootFXQuaternion), gameObject.transform);
    }
}
