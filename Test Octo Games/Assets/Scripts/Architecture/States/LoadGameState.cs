using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.States.Interfaces;

namespace Assets.Scripts.Architecture.States
{
    public class LoadGameState : IState
    {
        private const string GameScene = "Game";

        private readonly ISceneLoader _sceneLoader;

        public LoadGameState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _sceneLoader.Load(GameScene, InitializeGameWorld);
        }

        private void InitializeGameWorld()
        {
            UnityEngine.Debug.Log("InitializeGameWorld");
        }
    }
}