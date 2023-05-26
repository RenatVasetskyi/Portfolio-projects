using Assets.Scripts.Architecture;
using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.States;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(Restart);
            _exitButton.onClick.AddListener(Exit);
        }

        private void Exit() =>
            Application.Quit();

        private void Restart() =>
            AllServices.Container.Single<IStateMachine>().Enter<LoadGameState>();
    }
}