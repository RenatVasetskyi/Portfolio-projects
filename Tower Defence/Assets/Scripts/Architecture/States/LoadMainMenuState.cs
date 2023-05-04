using Assets.Scripts.Architecture.Services.Factories.UI;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.SceneManagement;

namespace Assets.Scripts.Architecture.States
{
    public class LoadMainMenuState : IState
    {
        private const string MainMenuScene = "Main";

        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;

        public LoadMainMenuState(ISceneLoader sceneLoader, IUIFactory uiFactory)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public void Exit()
        {
        }

        public void Enter() =>
            _sceneLoader.Load(MainMenuScene, OnLoaded);

        private void OnLoaded() =>
            InitMainMenu();

        private void InitMainMenu() =>
            _uiFactory.CreateMainMenu();
    }
}