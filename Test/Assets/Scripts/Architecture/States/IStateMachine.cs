using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.States.Interfaces;

namespace Assets.Scripts.Architecture.States
{
    public interface IStateMachine : IService
    {
        void Enter<TState>() where TState : class, IState;
    }
}