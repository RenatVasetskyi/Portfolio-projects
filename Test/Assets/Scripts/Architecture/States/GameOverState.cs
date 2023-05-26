using Assets.Scripts.Architecture.Services;

namespace Assets.Scripts.Architecture.States
{
    public class GameOverState : IState
    {
        private readonly AllServices _allServices;

        public GameOverState(AllServices allServices)
        {
            _allServices = allServices;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            AllServices.Container.Single<IMainFactory>().CreateGameOverView();
        }
    }
}