using Assets.Scripts.Architecture.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.GameOver.Buttons
{
    public class RestartGameButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private GameOverWindow _gameOverWindow;

        private void Awake() =>
            _button.onClick.AddListener(EnterLoadLevelState);

        private void EnterLoadLevelState() =>
            _gameOverWindow.StateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
    }
}