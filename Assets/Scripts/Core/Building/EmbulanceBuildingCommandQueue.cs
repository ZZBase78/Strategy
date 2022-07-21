using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Zenject;

namespace Core
{
    public class EmbulanceBuildingCommandQueue: MonoBehaviour, ICommandsQueue
    {
        public ICommand CurrentCommand => default;
        
        [Inject] CommandExecutorBase<IProduceHillUnitCommand> _produceHillUnitCommandExecutor;
        [Inject] CommandExecutorBase<ISetRallyPointCommand> _setRallyCommandExecutor;

        public void Clear() { }

        public async void EnqueueCommand(object command)
        {
            await _produceHillUnitCommandExecutor.TryExecuteCommand(command);
            await _setRallyCommandExecutor.TryExecuteCommand(command);
        }
    }
}