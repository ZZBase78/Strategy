﻿using System;
using System.Collections.Generic;
using System.Linq;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UserControlSystem.UI.View
{
    public sealed class CommandButtonsView : MonoBehaviour
    {
        public Action<ICommandExecutor> OnClick;

        [SerializeField] private GameObject _attackButton;
        [SerializeField] private GameObject _moveButton;
        [SerializeField] private GameObject _patrolButton;
        [SerializeField] private GameObject _stopButton;
        [SerializeField] private GameObject _produceUnitButton;

        private Dictionary<Type, GameObject> _buttonsByExecutorType;
        private List<IDisposable> buttonObservables;

        private void Start()
        {
            buttonObservables = new List<IDisposable>();

            _buttonsByExecutorType = new Dictionary<Type, GameObject>();
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IAttackCommand>), _attackButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IMoveCommand>), _moveButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IStopCommand>), _stopButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton);
        }
        public void BlockInteractions(ICommandExecutor ce)
        {
            UnblockAllInteractions();
            GETButtonGameObjectByType(ce.GetType())
                .GetComponent<Selectable>().interactable = false;
        }

        public void UnblockAllInteractions() => SetInteractible(true);

        private void SetInteractible(bool value)
        {
            _attackButton.GetComponent<Selectable>().interactable = value;
            _moveButton.GetComponent<Selectable>().interactable = value;
            _patrolButton.GetComponent<Selectable>().interactable = value;
            _stopButton.GetComponent<Selectable>().interactable = value;
            _produceUnitButton.GetComponent<Selectable>().interactable = value;
        }

        public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors)
        {
            foreach (var currentExecutor in commandExecutors)
            {
                var buttonGameObject = GETButtonGameObjectByType(currentExecutor.GetType());
                buttonGameObject.SetActive(true);
                var button = buttonGameObject.GetComponent<Button>();

                var buttonObservable = button.OnClickAsObservable().Subscribe(_ => OnClick?.Invoke(currentExecutor));
                buttonObservables.Add(buttonObservable);
            }
        }

        private GameObject GETButtonGameObjectByType(Type executorInstanceType)
        {
            return _buttonsByExecutorType
                .First(type => type.Key.IsAssignableFrom(executorInstanceType))
                .Value;
        }

        public void Clear()
        {
            foreach (var kvp in _buttonsByExecutorType)
            {
                kvp.Value
                    .GetComponent<Button>().onClick.RemoveAllListeners();
                kvp.Value.SetActive(false);
            }

            foreach (var button_observable in buttonObservables)
            {
                button_observable.Dispose();
            }
            buttonObservables.Clear();
        }
    }
}