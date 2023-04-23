using Assets.Scripts.Architecture.Factories;
using Assets.Scripts.Architecture.Main;
using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.UI;
using Zenject;

namespace Assets.Scripts.Architecture.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneLoader();
            BindUIFactory();
            BindStateMachine();
            BindWindowService();
            BindAssetProvider();
            BindStaticDataService();
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

        private void BindStateMachine()
        {
            Container
                .Bind<IStateMachine>()
                .To<StateMachine>()
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }
    }
}