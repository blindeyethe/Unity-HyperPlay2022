using UnityEngine;
using UnityEngine.SceneManagement;

public class obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            SceneManager.LoadScene("Game"); 
    }
}
