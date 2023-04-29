using Assets.Scripts.Waves;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.OnLevel.StartWave
{
    public class StartWaveButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private IWaveSystem _waveSystem;

        [Inject]
        public void Construct(IWaveSystem waveSystem) =>
            _waveSystem = waveSystem;

        private void Awake() =>
            _button.onClick.AddListener(()=> _waveSystem.RunStartWaveCoroutine());
    }
}