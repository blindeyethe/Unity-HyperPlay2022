using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ValueData finishedLvlData;
    [SerializeField] private ValueData coinsData;
    [SerializeField] private ValueData ballsData;
    
    private void Start() => LoadData();
    private void OnEnable() => PlatformFinish.OnLvlFinish += SaveData;
    private void OnDisable() => PlatformFinish.OnLvlFinish += SaveData;
    private void OnApplicationQuit() => SaveData();

    private void LoadData()
    {
        int levels = PlayerPrefs.GetInt("Levels");
        finishedLvlData.SetValue(levels);
        
        int coins = PlayerPrefs.GetInt("Coins");
        coinsData.SetValue(coins);

        int balls = PlayerPrefs.GetInt("Balls");
        ballsData.SetValue(balls);
    }
    
    private void SaveData()
    {
        PlayerPrefs.SetInt("Levels", finishedLvlData.GetValue());
        PlayerPrefs.SetInt("Coins", coinsData.GetValue());
        PlayerPrefs.SetInt("Balls", ballsData.GetValue());
    }
}
