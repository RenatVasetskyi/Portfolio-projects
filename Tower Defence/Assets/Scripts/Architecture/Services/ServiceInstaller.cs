using Assets.Scripts.Architecture.Main;
using Assets.Scripts.UI;
using Zenject;

namespace Assets.Scripts.Architecture.Services
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneLoader();
            BindStateMachine();
            BindWindowService();
            BindUIFactory();
            BindAssetProvider();
        }

        private void BindAssetProvider()
        {
            Container
                .Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle();
        }

        private void BindUIFactory()
        {
            Container
                .Bind<IUIFactory>()
                .To<UIFactory>()
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