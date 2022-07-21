using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IProduceHillUnitCommand : ICommand, IIconHolder
    {
        float ProductionTime { get; }
        GameObject UnitPrefab { get; }
        string UnitName { get; }
    }
}