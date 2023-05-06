using Assets.Scripts.Architecture.Services.Factories.UI;
using Assets.Scripts.Architecture.States.Interfaces;

namespace Assets.Scripts.Architecture.States
{
    public class GameOverState : IState
    {
        private readonly ILevelUIFactory _levelUIFactory;

        public GameOverState(ILevelUIFactory levelUIFactory) =>
            _levelUIFactory = levelUIFactory;

        public void Exit()
        {
        }

        public void Enter() =>
            _levelUIFactory.CreateGameOverWindow();
    }
}