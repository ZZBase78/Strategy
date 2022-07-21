using System;
using System.Threading;
using System.Threading.Tasks;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Assets.Scripts.Abstractions;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Utils;
using Zenject;

namespace Core.CommandExecutors
{
    public class HillCommandExecutor : CommandExecutorBase<IHillCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Idle = Animator.StringToHash("Idle");

        public override async Task ExecuteSpecificCommand(IHillCommand command)
        {
            GetComponent<NavMeshAgent>().destination = command.Target.Transform.position;
            _animator?.SetTrigger(Walk);
            _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await _stop
                    .WithCancellation
                    (
                        _stopCommandExecutor
                            .CancellationTokenSource
                            .Token
                    );
                HillTarget(command);
            }
            catch
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<NavMeshAgent>().ResetPath();
            }
            _stopCommandExecutor.CancellationTokenSource = null;
            _animator?.SetTrigger(Idle);
        }

        public void HillTarget(IHillCommand command)
        {
            var dest = transform.position - command.Target.Transform.position;
            if (dest.sqrMagnitude <= 5f)
            {
                Debug.Log("Hilling.......");
                command.Target.Hill(10);
            }
                
        }
    }
}