using UnityEngine;

public class TapInput : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    public delegate void TapControl(Vector3 tapPosition);
    public static event TapControl OnTapToScreen;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            GetTouchPosition();
        }
    }

    private void GetTouchPosition()
    {
        Touch touch = Input.GetTouch(0);
        OnTapToScreen?.Invoke(_camera.ScreenToWorldPoint(touch.position));
    }
}
