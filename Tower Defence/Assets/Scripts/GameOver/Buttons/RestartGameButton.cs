using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States;
using Assets.Scripts.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.GameOver.Buttons
{
    public class RestartGameButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private GameOverWindow _gameOverWindow;

        private IAudioService _audioService;

        [Inject]
        public void Construct(IAudioService audioService) =>
            _audioService = audioService;

        private void Awake() =>
            _button.onClick.AddListener(OnClick);

        private void OnClick()
        {
            _audioService.PlaySfx(SfxType.Click);
            _gameOverWindow.StateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
        }
    }
}