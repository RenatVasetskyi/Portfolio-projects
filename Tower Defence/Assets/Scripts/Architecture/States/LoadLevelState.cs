using Assets.Scripts.Architecture.Factories;
using Assets.Scripts.Architecture.Main;
using Assets.Scripts.Architecture.States.Interfaces;

namespace Assets.Scripts.Architecture.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;

        public LoadLevelState(IStateMachine stateMachine, ISceneLoader sceneLoader, IUIFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public void Exit()
        {
        }

        public void Enter(string nextScene) =>
            _sceneLoader.Load(nextScene, OnLoaded);

        private void InitGameWorld() =>
            _uiFactory.CreateMainMenu();

        private void OnLoaded()
        {
            InitGameWorld();
            _stateMachine.Enter<GameLoopState>();
        }
    }
}