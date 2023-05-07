using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Audio;
using Assets.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.MainMenu
{
    public class LevelTransferButton : MonoBehaviour
    {
        public LevelId LevelId;

        [SerializeField] private Button _button;

        private IStateMachine _stateMachine;
        private IAudioService _audioService;

        [Inject]
        public void Construct(IStateMachine stateMachine, IAudioService audioService)
        {
            _stateMachine = stateMachine;
            _audioService = audioService;
        }

        private void Awake() =>
            _button.onClick.AddListener(OnClick);

        private void OnClick()
        {
            _audioService.PlaySfx(SfxType.Click);
            _stateMachine.Enter<LoadLevelState, string>(LevelId.ToString());
        }
    }
}