using Assets.Scripts.Architecture.Main;

namespace Assets.Scripts.Architecture.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly StateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(StateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Exit()
        {
        }

        public void Enter(string nextScene) =>
            _sceneLoader.Load(nextScene, OnLoaded);

        private void InitGameWorld()
        {

        }

        private void OnLoaded()
        {
            InitGameWorld();
            _stateMachine.Enter<GameLoopState>();
        }
    }
}