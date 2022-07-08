using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UserControlSystem;

public abstract class ScriptableObjectStatefullBase<T> : ScriptableObjectValueBase<T>
{
    public ReactiveProperty<T> ReactiveValue;

    public override void SetValue(T value)
    {
        base.SetValue(value);

        ReactiveValue.Value = value;
    }
}
