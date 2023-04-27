using Assets.Scripts.Architecture.Factories;
using Assets.Scripts.Architecture.Main;
using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data.Levels;
using Assets.Scripts.Scenes;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private MyCoroutineRunner _coroutineRunner;
        [SerializeField] private AllLevelsSettings _allLevelsSettings;

        public override void InstallBindings()
        {
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