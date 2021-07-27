using System.Collections;
using UnityEngine;

public class PlayerImmortal : MonoBehaviour
{
    [SerializeField]
    private float _immortalCoolDown;
    private WaitForSeconds _immortalWait;
    public delegate void ImmortalState();
    public static event ImmortalState OnImmortalStart;
    public static event ImmortalState OnImmortalEnd;

    private void Awake()
    {
        _immortalWait = new WaitForSeconds(_immortalCoolDown);
    }

    private void OnEnable()
    {
        PlayerHealth.OnDamageTaked += MakeImmortal;
    }

    private void OnDisable()
    {
        PlayerHealth.OnDamageTaked -= MakeImmortal;
    }

    private void MakeImmortal()
    {
        StartCoroutine(SetImmortalState());
    }

    private IEnumerator SetImmortalState()
    {
        OnImmortalStart?.Invoke();
        yield return _immortalWait;
        OnImmortalEnd?.Invoke();
    }
}
