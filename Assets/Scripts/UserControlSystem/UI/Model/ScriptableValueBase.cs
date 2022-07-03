using System;
using UnityEngine;

public class ScriptableValueBase<T> : ScriptableObject
{
    public T CurrentValue { get; private set; }
    public Action<T> OnNewValue;

    public void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }
}
