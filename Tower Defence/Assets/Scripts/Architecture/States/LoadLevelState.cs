using Assets.Scripts.Architecture.Factories;
using Assets.Scripts.Architecture.Main;
using Assets.Scripts.Architecture.States.Interfaces;

namespace Assets.Scripts.Architecture.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadLevelState(IStateMachine stateMachine, ISceneLoader sceneLoader)
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