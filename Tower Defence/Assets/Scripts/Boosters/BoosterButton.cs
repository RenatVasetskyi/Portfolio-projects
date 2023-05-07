using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Boosters
{
    public class BoosterButton : MonoBehaviour
    {
        public BoosterType BoosterType;
        public bool IsActivated;

        [SerializeField] private Button _button;

        private IAudioService _audioService;

        [Inject]
        public void Construct(IAudioService audioService) => 
            _audioService = audioService;

        public void OffButton()
        {
            IsActivated = false;
            _button.interactable = false;
        }

        private void Awake() =>
            _button.onClick.AddListener(OnClick);

        private void OnClick()
        {
            _audioService.PlaySfx(SfxType.Click);

            if (IsActivated == true)
                IsActivated = false;
            else
                IsActivated = true;
        }
    }
}