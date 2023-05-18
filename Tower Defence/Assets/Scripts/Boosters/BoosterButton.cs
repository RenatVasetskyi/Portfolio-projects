using Assets.Scripts.Architecture.Services.Factories.UI;
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

        protected IAudioService _audioService;
        private IUIFactory _uiFactory;

        [Inject]
        public void Construct(IAudioService audioService, IUIFactory uiFactory)
        {
            _audioService = audioService;
            _uiFactory = uiFactory;
        }

        public virtual void OffButton()
        {
            IsActivated = false;
            Button.interactable = false;
        }

        private void Awake() =>
            Button.onClick.AddListener(OnClick);

        protected virtual void OnClick()
        {
            if (CheckIsTowerNotSelected())
                return;

            _audioService.PlaySfx(SfxType.BoosterSelection);

            if (IsActivated == true)
                IsActivated = false;
            else
                IsActivated = true;
        }

        private bool CheckIsTowerNotSelected()
        {
            if (_uiFactory.TowerSelection.SelectedButton != null)
                return true;
            return false;
        }
    }
}