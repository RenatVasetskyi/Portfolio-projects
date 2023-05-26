using Assets.Scripts.Architecture.Services;

namespace Assets.Scripts.Architecture.States
{
    public interface IStateMachine : IService
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
    }
}