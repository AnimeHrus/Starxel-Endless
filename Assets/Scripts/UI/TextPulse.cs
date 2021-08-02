using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextPulse : MonoBehaviour
{
    [SerializeField] private float _scaleSize;
    [SerializeField] private float _scaleChangeSpeed;
    private float _startScale;
    private float _targedScale;
    private WaitForEndOfFrame _endFrameWait;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
        _endFrameWait = new WaitForEndOfFrame();
        _startScale = _text.rectTransform.localScale.x;
        _targedScale = _startScale + _scaleSize;
    }

    private void OnEnable()
    {
        EnemyHealth.OnEnemyKilled += StartPulse;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyKilled -= StartPulse;
    }

    private void StartPulse()
    {
        StartCoroutine(Pulsating());
    }

    private IEnumerator Pulsating()
    {
        for (float i = _startScale; i <= _targedScale; i += _scaleChangeSpeed)
        {
            _text.rectTransform.localScale = new Vector3(i, i, 1);
            yield return _endFrameWait;
        }
        _text.rectTransform.localScale = new Vector3(_targedScale, _targedScale, 1);
        for (float i = _targedScale; i >= _startScale; i -= _scaleChangeSpeed)
        {
            _text.rectTransform.localScale = new Vector3(i, i, 1);
            yield return _endFrameWait;
        }
        _text.rectTransform.localScale = new Vector3(_startScale, _startScale, 1);
    }
}
