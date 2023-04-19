using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;

namespace Assets.Scripts.Architecture.Main
{
    public class LoadProgressState : IState
    {
        private readonly StateMachine _stateMachine;

        public LoadProgressState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            LoadProgressOrInitNew();

            _stateMachine.Enter<LoadLevelState, string>(Scenes.Main);
        }

        private void LoadProgressOrInitNew()
        {

        }
    }
}