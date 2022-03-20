using System;

public class UiAction
{
    private event Action Action;

    public void AddListener(Action listener) => Action += listener;
    public void RemoveListener(Action listener) => Action -= listener;
    
    public void Invoke() => Action?.Invoke();
}

public class UiAction<T>
{
    private event Action<T> Action;

    public void AddListener(Action<T> listener) => Action += listener;
    public void RemoveListener(Action<T> listener) => Action -= listener;
    
    public void Invoke(T param) => Action?.Invoke(param);
}

public class UiAction<T1, T2>
{
    private event Action<T1, T2> Action;

    public void AddListener(Action<T1, T2> listener) => Action += listener;
    public void RemoveListener(Action<T1, T2> listener) => Action -= listener;
    
    public void Invoke(T1 param1, T2 param2) => Action?.Invoke(param1, param2);
}
