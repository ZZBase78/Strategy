using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;
using Zenject;

namespace UserControlSystem.CommandsRealization
{
    public class ProduceHillUnitCommand : IProduceHillUnitCommand
    {
        [Inject(Id = "Hiller")] public string UnitName { get; }
        [Inject(Id = "Hiller")] public Sprite Icon { get; }
        [Inject(Id = "Hiller")] public float ProductionTime { get; }

        public GameObject UnitPrefab => _unitPrefab;
        [InjectAsset("Hiller")] private GameObject _unitPrefab;
    }
}