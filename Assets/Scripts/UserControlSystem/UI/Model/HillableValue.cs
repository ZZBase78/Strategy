using System;
using Abstractions;
using UnityEngine;
using Utils;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(HillableValue), menuName = "Strategy Game/" + nameof(HillableValue), order = 0)]
    public sealed class HillableValue : StatelessScriptableObjectValueBase<IHillable>
    {
        
    }
}