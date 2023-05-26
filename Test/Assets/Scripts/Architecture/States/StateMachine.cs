using System;
using System.Collections.Generic;
using Assets.Scripts.Architecture.Services;

namespace Assets.Scripts.Architecture.States
{
    public class StateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public StateMachine(AllServices allServices)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, allServices),
                [typeof(LoadGameState)] = new LoadGameState(allServices),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}