using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
    private const int PLATFORMS_PER_FINISHED_LEVEL = 5;
    
    [SerializeField] private ValueData finishedLvlData;
    [SerializeField] private PlatformsData platformsData;
    [SerializeField] private Transform skyDome;
    
    [Space(10)]
    [SerializeField] private float platformsLength = 31.46331f;
    [SerializeField] private int platformsAtStart = 5;

    private int _maxPlatforms;
    private int _spawnedPlatforms;
    private float _zSpawn;
    private bool _finishHit;

    private void OnEnable() => PlatformDestroy.OnDestroy += SpawnPlatform;
    private void OnDisable() => PlatformDestroy.OnDestroy -= SpawnPlatform;

    private void Start()
    {
        _maxPlatforms = finishedLvlData.GetValue() + PLATFORMS_PER_FINISHED_LEVEL;
        
        skyDome.localScale = new Vector3(28f, 13f, _maxPlatforms * platformsLength);
        
        for (int i = 0; i < platformsAtStart; i++)
            SpawnPlatform();
    }
    
    private void SpawnPlatform()
    {
        if (_finishHit)
            return;
        
        if (_spawnedPlatforms == 0)
        {
            InstantiatePlatform(platformsData.RandomStart.prefab);
        }
        else if (_spawnedPlatforms == _maxPlatforms)
        {
            InstantiatePlatform(finishedLvlData.GetValue() % 2 == 1 ? 
                platformsData.RandomBoss.prefab : platformsData.RandomEnd.prefab);
            
            _finishHit = true;
        }
        else 
            InstantiatePlatform(platformsData.RandomMiddle.prefab);

        _spawnedPlatforms++;
        _zSpawn += platformsLength; 
    }

    private void InstantiatePlatform(GameObject platform)
    {
        Instantiate(platform, Vector3.forward * _zSpawn, Quaternion.identity);
    }
}
