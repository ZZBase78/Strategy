using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using Core;
using Core.CommandExecutors;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserControlSystem;
using Utils;
using Zenject;

public class HillerAutoMoveRMB : MonoBehaviour
{
    [Inject] private AutoMoveRMBData _autoMoveRMBData;
    [Inject] private CommandCreatorBase<IMoveCommand> _commandCreator;
    private MoveCommandExecutor _commandExecutor;
    private ISelectable _thisUnit;
    private HillerCommandsQueue _hillerCommandsQueue;

    private void Awake()
    {
        _commandExecutor = gameObject.GetComponentInParent<MoveCommandExecutor>();
        _thisUnit = gameObject.GetComponentInParent<ISelectable>();
        _hillerCommandsQueue = gameObject.GetComponentInParent<HillerCommandsQueue>();
    }

    private void Start()
    {
        _autoMoveRMBData.vector3Value.OnNewValue += RMB_Pressed;
    }

    private void RMB_Pressed(Vector3 vector3)
    {
        if (_autoMoveRMBData.selectableValue.CurrentValue != _thisUnit)
            return;
        _hillerCommandsQueue.EnqueueCommand(new MoveCommand(vector3));

    }
}
