using System;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    public static event Action OnDestroy;
    
    [SerializeField] private GameObject platform;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            Destroy();
    }

    private void Destroy()
    {
        OnDestroy?.Invoke();
        Destroy(platform);
    }
}
