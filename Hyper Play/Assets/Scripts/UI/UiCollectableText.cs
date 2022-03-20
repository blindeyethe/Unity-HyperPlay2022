using UnityEngine;
using TMPro;

public class UiCollectableText : MonoBehaviour
{
    [SerializeField] private ValueData valueData;
    [SerializeField] private TMP_Text text;
    [SerializeField] private string baseText;

    private void OnEnable() => valueData.OnValueChange += UpdateCount;
    private void OnDisable() => valueData.OnValueChange -= UpdateCount;

    private void UpdateCount(int coinValue) => text.SetText(baseText + coinValue);
}
