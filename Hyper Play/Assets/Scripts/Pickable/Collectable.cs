using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private ValueData valueData;
    [SerializeField] private int value = 1;
    
    public void PickUp()
    {
        valueData.AddValue(value);
        Destroy(gameObject);
    }
}
