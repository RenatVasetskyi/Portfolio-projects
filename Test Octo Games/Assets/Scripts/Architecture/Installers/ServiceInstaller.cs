using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.Services.Interfaces;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private MyCoroutineRunner _coroutineRunner;

        public override void InstallBindings()
        {
            BindCoroutineRunner();
            BindSceneLoader();
            BindAssetProvider();
            BindBaseFactory();
            BindPlayerInput();
        }

        private void BindPlayerInput()
        {
            PlayerInput input = new PlayerInput();

            input.Enable();

            Container
                .Bind<PlayerInput>()
                .FromInstance(input)
                .AsSingle()
                .NonLazy();
        }

        private void BindBaseFactory()
        {
            Container
                .Bind<IBaseFactory>()
                .To<BaseFactory>()
                .AsSingle();
        }

        private void BindAssetProvider()
        {
            Container
                .Bind<IAssetProvider>()
                .To<AssetProvider>()
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

            Container
                .Bind<ICoroutineRunner>()
                .To<MyCoroutineRunner>()
                .FromInstance(runner);
        }
    }
}