using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformFinish : MonoBehaviour
{
    public static event Action OnLvlFinish;
    
    [SerializeField] private ValueData finishedLvlData;
    [SerializeField] private string scene;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) 
            return;
        
        finishedLvlData.AddValue(1);
        OnLvlFinish?.Invoke();
        SceneManager.LoadScene(scene);
    }
}
