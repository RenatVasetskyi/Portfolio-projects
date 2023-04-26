using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.Services.Interfaces;
using Zenject;

namespace Assets.Scripts.Architecture.Installers
{
    public class LocalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLocalCoinService();
        }

        private void BindLocalCoinService()
        {
            Container
                .Bind<ILocalCoinService>()
                .To<LocalCoinService>()
                .AsSingle()
                .NonLazy();
        }
    }
}