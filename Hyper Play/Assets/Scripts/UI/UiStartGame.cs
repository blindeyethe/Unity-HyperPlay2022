using System;
using UnityEngine;

public class UiStartGame : MonoBehaviour
{
    public static event Action OnGameStart;
    
    [SerializeField] private GameObject[] menuItems;

    private bool _started;
    
    private void Update()
    {
        if (_started)
            return;
        
        if (!SwipeManager.tap)
            return;

        Play();
    }

    private void Play()
    {
        foreach (var item in menuItems)
            item.SetActive(false); 
        
        OnGameStart?.Invoke();

        _started = true;
    }
}
