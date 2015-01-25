using UnityEngine;

public class CanTakeDamageComponent : MonoBehaviour
{
    void TakeDamage()
    {
        gameObject.SetActive(false);
    }
}
