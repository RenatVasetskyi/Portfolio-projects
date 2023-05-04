using Assets.Scripts.Architecture.Main;
using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.Services.Factories.UI;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Data.Levels;
using Assets.Scripts.SceneManagement;
using Assets.Scripts.UI.Loading;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private MyCoroutineRunner _coroutineRunner;
        [SerializeField] private AllLevelsSettings _allLevelsSettings;
        [SerializeField] private LoadingCurtain _loadingCurtain;

        public override void InstallBindings()
        {
            BindLoadingCurtain();
            BindSceneLoader();
            BindUIFactory();
            BindWindowService();
            BindAssetProvider();
            BindStaticDataService();
            BindCoroutineRunner();
            BindAllLevels();
            BindLocalCoinService();
            BindCurrentLevelSettingsProvider();
            BindPlayerHpService();
            BindPlayerInput();
        }

        private void BindPlayerInput()
        {
            PlayerInput input = new PlayerInput();

            input.Enable();

            Container
                .Bind<PlayerInput>()
                .FromInstance(input)
                .AsSingle();
        }

        private void BindLoadingCurtain()
        {
            LoadingCurtain loadingCurtain = Container
                .InstantiatePrefabForComponent<LoadingCurtain>(_loadingCurtain);

            Container
                .Bind<LoadingCurtain>()
                .FromInstance(loadingCurtain)
                .AsSingle();
        }

        private void BindPlayerHpService()
        {
            Container
                .Bind<IPlayerHpService>()
                .To<PlayerHpService>()
                .AsSingle();
        }

        private void BindCurrentLevelSettingsProvider()
        {
            Container
                .Bind<ICurrentLevelSettingsProvider>()
                .To<CurrentLevelSettingsProvider>().AsSingle();
        }

        private void BindLocalCoinService()
        {
            Container
                .Bind<ILocalCoinService>()
                .To<LocalCoinService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindUIFactory()
        {
            Container
                .Bind<IUIFactory>()
                .To<UIFactory>()
                .AsSingle();
        }

        private void BindStaticDataService()
        {
            Container
                .Bind<IStaticDataService>()
                .To<StaticDataService>()
                .AsSingle();
        }

        private void BindAssetProvider()
        {
            Container
                .Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle();
        }

        private void BindWindowService()
        {
            Container
                .Bind<IWindowService>()
                .To<WindowService>()
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }

        private void BindCoroutineRunner()
        {
            MyCoroutineRunner runner = Container.InstantiatePrefabForComponent<MyCoroutineRunner>(_coroutineRunner);
            Container.Bind<ICoroutineRunner>().To<MyCoroutineRunner>().FromInstance(runner);
        }

        private void BindAllLevels()
        {
            Container
                .Bind<AllLevelsSettings>()
                .FromScriptableObject(_allLevelsSettings)
                .AsSingle();
        }
    }
}