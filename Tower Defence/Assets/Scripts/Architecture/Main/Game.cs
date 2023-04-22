using Assets.Scripts.Architecture.Services;

namespace Assets.Scripts.Architecture.Main
{
    public class Game
    {
        private readonly IUIFactory _uiFactory;
        public StateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            StateMachine = new StateMachine(new SceneLoader(coroutineRunner), _uiFactory);
        }
    }
}
