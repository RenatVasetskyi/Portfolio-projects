using Assets.Scripts.Architecture.Services.Factories.UI;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Audio;
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
        private readonly IAudioService _audioService;

        public LoadMainMenuState(ISceneLoader sceneLoader, IUIFactory uiFactory, LoadingCurtain loadingCurtain, IAudioService audioService)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _loadingCurtain = loadingCurtain;
            _audioService = audioService;
        }

        public void Exit()
        {
            _audioService.StopMusic();
        }

        public void Enter()
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(MainMenuScene, InitMainMenu);
            _audioService.PlayMusic(MusicType.MainMenu);
        }

        private void InitMainMenu()
        {
            _uiFactory.CreateMainMenu();
            _loadingCurtain.Hide();
        }
    }
}