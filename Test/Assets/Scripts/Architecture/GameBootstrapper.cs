using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.States;
using UnityEngine;

namespace Assets.Scripts.Architecture
{
    public class GameBootstrapper : MonoBehaviour
    {
        private StateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new StateMachine(AllServices.Container);
            _stateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}