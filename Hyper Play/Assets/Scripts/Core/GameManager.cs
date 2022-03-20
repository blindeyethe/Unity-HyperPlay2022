using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const int BALL_VALUE = 2;
    
    [SerializeField] private ValueData finishedLvlData;
    [SerializeField] private ValueData bossCoinsData;
    [SerializeField] private ValueData coinsData;
    [SerializeField] private ValueData ballsData;
    [SerializeField] private Material skin1;
    [SerializeField] private SkinData skinData;
    [SerializeField] private SkinnedMeshRenderer playerRenderer;
    [SerializeField] private Material skin2;
    
    private void Start() => LoadData();
    private void OnEnable() => PlatformFinish.OnLvlFinish += OnFinish;

    private void OnFinish(bool isBoss)
    {
        if (isBoss)
            CalculateMultiply();
        
        SaveData();
    }

    private void OnDisable() => PlatformFinish.OnLvlFinish += OnFinish;
    private void OnApplicationQuit() => SaveData();

    private void LoadData()
    {
        int levels = PlayerPrefs.GetInt("Levels");
        finishedLvlData.SetValue(levels);
        
        int coins = PlayerPrefs.GetInt("Coins");
        coinsData.SetValue(coins);

        int balls = PlayerPrefs.GetInt("Balls");
        ballsData.SetValue(balls);
        
        skinData.skinIndex = PlayerPrefs.GetInt("Skin");
        playerRenderer.material = skinData.GetSkin;
    }
    
    private void SaveData()
    {
        PlayerPrefs.SetInt("Levels", finishedLvlData.GetValue());
        PlayerPrefs.SetInt("Coins", coinsData.GetValue());
        PlayerPrefs.SetInt("Balls", ballsData.GetValue());
        PlayerPrefs.SetInt("Skin", skinData.skinIndex);
    }

    private void CalculateMultiply()
    {
        int value = coinsData.GetValue() + ( ballsData.GetValue() * BALL_VALUE);
        coinsData.AddValue(value);
        ballsData.SetValue(0);
        bossCoinsData.SetValue(value);
    }

    public void Skin()
    {
        skinData.skinIndex = 1;
        coinsData.SubValue(500);
        playerRenderer.material = skin1;
    }
    
    public void Skin2()
    {
        skinData.skinIndex = 2;
        coinsData.SubValue(1500);
        playerRenderer.material = skin2;
    }
}
