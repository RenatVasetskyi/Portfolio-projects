using Assets.Scripts.Architecture.Factories;
using Assets.Scripts.Architecture.States;

namespace Assets.Scripts.Architecture.Main
{
    public class Game
    {
        public StateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, IUIFactory uiFactory)
        {
            StateMachine = new StateMachine(new SceneLoader(coroutineRunner), uiFactory);
        }
    }
}
