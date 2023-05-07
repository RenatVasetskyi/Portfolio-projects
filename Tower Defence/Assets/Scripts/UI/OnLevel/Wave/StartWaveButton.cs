using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Audio;
using Assets.Scripts.Waves;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.OnLevel.Wave
{
    public class StartWaveButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private IWaveSystem _waveSystem;
        private IAudioService _audioService;

        [Inject]
        public void Construct(IWaveSystem waveSystem, IAudioService audioService)
        {
            _waveSystem = waveSystem;
            _audioService = audioService;
        }

        private void Awake() =>
            _button.onClick.AddListener(OnClick);

        private void OnClick()
        {
            _audioService.PlaySfx(SfxType.Click);
            _button.interactable = false;
            _waveSystem.RunStartWaveCoroutine();
        }
    }
}