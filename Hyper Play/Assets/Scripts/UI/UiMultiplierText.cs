using UnityEngine;

public class UiMultiplierText : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    
    private void OnEnable() => PlatformFinish.OnLvlFinish += Enable;
    private void OnDisable() => PlatformFinish.OnLvlFinish -= Enable;

    private void Enable(bool isBoss) => ui.SetActive(isBoss);
}
