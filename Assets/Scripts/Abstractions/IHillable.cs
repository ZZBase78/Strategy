using Abstractions;
using UnityEngine;

public interface IHillable : IHealthHolder
{
    void Hill(int amount);

    Transform Transform { get; }
}