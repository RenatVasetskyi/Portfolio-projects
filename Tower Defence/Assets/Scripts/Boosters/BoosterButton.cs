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
        public Button Button;

        private IAudioService _audioService;

        [Inject]
        public void Construct(IAudioService audioService) => 
            _audioService = audioService;

        public virtual void OffButton()
        {
            IsActivated = false;
            Button.interactable = false;
        }

        private void Awake() =>
            Button.onClick.AddListener(OnClick);

        protected virtual void OnClick()
        {
            _audioService.PlaySfx(SfxType.BoosterSelection);

            if (IsActivated == true)
                IsActivated = false;
            else
                IsActivated = true;
        }
    }
}