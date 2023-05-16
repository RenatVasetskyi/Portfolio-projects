using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;
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

        private IAudioService _audioService;
        private IStateMachine _stateMachine;

        [Inject]
        public void Construct(IAudioService audioService, IStateMachine stateMachine)
        {
            _audioService = audioService;
            _stateMachine = stateMachine;
        }

        private void Awake() =>
            _button.onClick.AddListener(OnClick);

        private void OnClick()
        {
            _audioService.PlaySfx(SfxType.Click);
            _stateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
        }
    }
}