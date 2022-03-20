using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformFinish : MonoBehaviour
{
    public static event Action<bool> OnLvlFinish;
    
    [SerializeField] private ValueData finishedLvlData;
    [SerializeField] private float celebratingTime = 6f;
    [SerializeField] private string scene;
    [SerializeField] private bool isBoss;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) 
            return;
        
        finishedLvlData.AddValue(1);
        
        OnLvlFinish?.Invoke(isBoss);
        StartCoroutine(Celebrating());
    }

    private IEnumerator Celebrating()
    {
        yield return new WaitForSeconds(celebratingTime);
        SceneManager.LoadScene(scene);
    }
}
