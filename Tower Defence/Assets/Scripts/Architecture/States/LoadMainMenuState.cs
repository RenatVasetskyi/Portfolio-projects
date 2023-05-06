using System;
using Assets.Scripts.Architecture.Services.Factories.UI;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.SceneManagement;
using Assets.Scripts.UI.Loading;

namespace Assets.Scripts.Architecture.States
{
    public class LoadMainMenuState : IState
    {
        private const string MainMenuScene = "Main";

        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadMainMenuState(ISceneLoader sceneLoader, IUIFactory uiFactory, LoadingCurtain loadingCurtain)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _loadingCurtain = loadingCurtain;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(MainMenuScene, InitMainMenu);
        }

        private void InitMainMenu()
        {
            _uiFactory.CreateMainMenu();
            _loadingCurtain.Hide();
        }
    }
}