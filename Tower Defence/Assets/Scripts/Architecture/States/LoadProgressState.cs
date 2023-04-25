using Assets.Scripts.Architecture.States.Interfaces;

namespace Assets.Scripts.Architecture.States
{
    public class LoadProgressState : IState
    {
        private readonly IStateMachine _stateMachine;

        public LoadProgressState(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            LoadProgressOrInitNew();

            _stateMachine.Enter<LoadLevelState, string>(Main.Scenes.Main);
        }

        private void LoadProgressOrInitNew()
        {

        }
    }
}