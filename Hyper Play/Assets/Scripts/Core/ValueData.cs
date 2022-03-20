using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewValue Data", menuName = "Data/Value")]
public class ValueData : ScriptableObject
{
    public event Action<int> OnValueChange;
    
    private int _value = 0;

    private void OnEnable() => _value = 0;

    public int GetValue() => _value;
    
    public void SetValue(int subValue)
    {
        _value = subValue;
        OnValueChange?.Invoke(_value);
    }
    
    public void AddValue(int addedValue)
    {
        _value += addedValue;
        OnValueChange?.Invoke(_value);
    }

    public void SubValue(int subValue)
    {
        _value -= subValue;
        OnValueChange?.Invoke(_value);
    }
    
}
