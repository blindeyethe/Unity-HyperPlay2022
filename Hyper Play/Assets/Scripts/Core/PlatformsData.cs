using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Platform
{
    public GameObject prefab;
    [Range(0,100)] public float chance;
}

[CreateAssetMenu(fileName = "PlatformsData", menuName = "Data/Platforms Data", order = 0)]
public class PlatformsData : ScriptableObject
{
    [SerializeField] private Platform[] startPlatforms;
    [SerializeField] private Platform[] middlePlatforms;
    [SerializeField] private Platform[] endPlatforms;
    [SerializeField] private Platform[] bossPlatforms;

    public Platform RandomStart => Test(startPlatforms);
    public Platform RandomMiddle => Test(middlePlatforms);
    public Platform RandomEnd => Test(endPlatforms);
    public Platform RandomBoss => Test(bossPlatforms);

    private int _randomCache;

    private Platform Test(IReadOnlyList<Platform> a)
    {
        var b = a[RandomNumber(a.Count)];

        float randomChance = Random.Range(0, 100f);
        if (randomChance > b.chance)
            b = Test(a);
        
        return b;
    }
    
    private int RandomNumber(int maxNumber)
    {
        int randomNumber = Random.Range(0, maxNumber);
        for(int i = 0; randomNumber == _randomCache && i < 5; i++)
            randomNumber = Random.Range(0, maxNumber);
        
        _randomCache = randomNumber;
        return randomNumber;
    }
}
