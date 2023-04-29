using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.SceneManagement;

namespace Assets.Scripts.Architecture.States
{
    public class BootstrapState : IState
    {
        private const string InitialScene = "Initial";

        private readonly IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public BootstrapState(IStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Exit()
        {
        }

        public void Enter() =>
            _sceneLoader.Load(InitialScene, EnterLoadProgressState);

        private void EnterLoadProgressState() => 
            _stateMachine.Enter<LoadProgressState>();
    }
}