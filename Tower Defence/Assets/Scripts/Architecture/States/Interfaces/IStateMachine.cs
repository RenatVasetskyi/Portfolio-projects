using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;

namespace Assets.Scripts.Architecture.Main
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
    }
}