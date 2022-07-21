using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using Core;
using Core.CommandExecutors;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UserControlSystem;
using Utils;
using Zenject;

public class AutoMoveRMB : MonoBehaviour
{
    [Inject] private AutoMoveRMBData _autoMoveRMBData;
    [Inject] private CommandCreatorBase<IMoveCommand> _commandCreator;
    private MoveCommandExecutor _commandExecutor;
    private ISelectable _thisUnit;
    private ChomperCommandsQueue _chomperCommandsQueue;
    private bool _commandIsPending = false;

    private void Awake()
    {
        _commandExecutor = gameObject.GetComponentInParent<MoveCommandExecutor>();
        _thisUnit = gameObject.GetComponentInParent<ISelectable>();
        _chomperCommandsQueue = gameObject.GetComponentInParent<ChomperCommandsQueue>();
        MessageBroker.Default.Receive<CommandPending>().Subscribe(CommandPending_Changed);
    }

    private void CommandPending_Changed(CommandPending commandPending)
    {
        _commandIsPending = commandPending.value;
    }

    private void Start()
    {
        _autoMoveRMBData.vector3Value.OnNewValue += RMB_Pressed;
    }

    private void RMB_Pressed(Vector3 vector3)
    {
        if (_commandIsPending)
            return;
        if (_autoMoveRMBData.selectableValue.CurrentValue != _thisUnit)
            return;
        _chomperCommandsQueue.EnqueueCommand(new MoveCommand(vector3));

    }
}
