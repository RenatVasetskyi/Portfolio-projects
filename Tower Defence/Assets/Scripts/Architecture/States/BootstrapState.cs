using Assets.Scripts.Architecture.Main;
using Assets.Scripts.Architecture.States.Interfaces;

namespace Assets.Scripts.Architecture.States
{
    public class BootstrapState : IState
    {
        private const string InitialScene = "Initial";

        private readonly StateMachine _stateMachine;
        private  readonly SceneLoader _sceneLoader;

        public BootstrapState(StateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Exit()
        {
        }

        public void Enter() =>
            _sceneLoader.Load(InitialScene, EnterLoadLevel);

        public void EnterLoadLevel() => 
            _stateMachine.Enter<LoadProgressState>();
    }
}