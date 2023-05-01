using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Waves;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.OnLevel.Wave
{
    public class DisplayWaveCount : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _waveCountText;
        private IWaveSystem _waveSystem;
        private ICurrentLevelSettingsProvider _currentLevelSettingsProvider;

        [Inject]
        public void Construct(IWaveSystem waveSystem, ICurrentLevelSettingsProvider currentLevelSettingsProvider)
        {
            _waveSystem = waveSystem;
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
        }

        private void Awake() =>
            _waveSystem.OnWaveNumberChanged += UpdateCountText;

        private void UpdateCountText(int waveCount) =>
            _waveCountText.text = $"{waveCount}/{_currentLevelSettingsProvider.GetCurrentLevelSettings().WaveSettings.WaveDatas.Count}";
    }
}