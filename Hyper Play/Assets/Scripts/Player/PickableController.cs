using UnityEngine;

public class PickableController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var collectable = other.GetComponent<Collectable>();
        if (collectable == null)
            return;
        
        collectable.PickUp();
    }
}