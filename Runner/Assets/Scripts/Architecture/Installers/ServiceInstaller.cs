using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Input;
using Zenject;

namespace Assets.Scripts.Architecture.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInput();
            BindInputService();
            BindSwipeDetector();
        }

        private void BindSwipeDetector()
        {
            Container
                .Bind<ISwipeDetector>()
                .To<SwipeDetector>()
                .AsSingle()
                .NonLazy();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .To<InputService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindInput()
        {
            PlayerInput input = new PlayerInput();

            input.Enable();

            Container
                .Bind<PlayerInput>()
                .FromInstance(input)
                .AsSingle().NonLazy();
        }
    }
}