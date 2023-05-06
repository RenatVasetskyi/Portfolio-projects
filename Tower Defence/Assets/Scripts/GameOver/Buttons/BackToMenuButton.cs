using Assets.Scripts.Architecture.States;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GameOver.Buttons
{
    public class BackToMenuButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private GameOverWindow _gameOverWindow;

        private void Awake() =>
            _button.onClick.AddListener(EnterLoadLevelState);

        private void EnterLoadLevelState() =>
            _gameOverWindow.StateMachine.Enter<LoadMainMenuState>();
    }
}