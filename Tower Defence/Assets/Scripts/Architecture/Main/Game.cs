namespace Assets.Scripts.Architecture.Main
{
    public class Game
    {
        public StateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        { 
            StateMachine = new StateMachine(new SceneLoader(coroutineRunner));
        }
    }
}
