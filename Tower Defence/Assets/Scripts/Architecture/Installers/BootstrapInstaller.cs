using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;
using Zenject;

namespace Assets.Scripts.Architecture.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            BindInterfaces();
            BindStateMachine(); 
            BindStates();
            AddStatesToStateMachine();
        }

        public void Initialize() => 
            Container.Resolve<IStateMachine>().Enter<BootstrapState>();

        private void BindInterfaces() =>
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle().NonLazy();

        private void BindStates()
        {
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<LoadProgressState>().AsSingle();
            Container.Bind<LoadMainMenuState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
        }

        private void AddStatesToStateMachine()
        {
            IStateMachine stateMachine = Container.Resolve<IStateMachine>();

            stateMachine.States.Add(typeof(BootstrapState), Container.Resolve<BootstrapState>());
            stateMachine.States.Add(typeof(LoadProgressState), Container.Resolve<LoadProgressState>());
            stateMachine.States.Add(typeof(LoadMainMenuState), Container.Resolve<LoadMainMenuState>());
            stateMachine.States.Add(typeof(LoadLevelState), Container.Resolve<LoadLevelState>());
        }

        private void BindStateMachine()
        {
            Container
                .Bind<IStateMachine>()
                .To<StateMachine>()
                .AsSingle();
        }
    }
}