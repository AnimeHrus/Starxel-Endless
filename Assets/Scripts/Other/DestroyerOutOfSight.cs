using UnityEngine;

public class DestroyerOutOfSight : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
