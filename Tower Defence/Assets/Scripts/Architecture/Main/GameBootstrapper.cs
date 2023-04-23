using Assets.Scripts.Architecture.Factories;
using Assets.Scripts.Architecture.States;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Main
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private IUIFactory _uiFactory;

        [Inject]
        public void Construct(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        private void Awake()
        {
            _game = new Game(this, _uiFactory);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
