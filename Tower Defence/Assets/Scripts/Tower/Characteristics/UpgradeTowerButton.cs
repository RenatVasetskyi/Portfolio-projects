using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Tower.Characteristics
{
    public class UpgradeTowerButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TowerCharacteristics _towerCharacteristics;

        private IAudioService _audioService;

        [Inject]
        public void Construct(IAudioService audioService) =>
            _audioService = audioService;

        private void Awake() =>
            _button.onClick.AddListener(OnUpgradeTowerButtonClickHandler);

        private void OnUpgradeTowerButtonClickHandler()
        {
            _audioService.PlaySfx(SfxType.Click);
            _towerCharacteristics.Upgrade();
        }
    }
}