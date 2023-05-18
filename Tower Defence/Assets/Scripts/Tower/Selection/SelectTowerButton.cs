using Assets.Scripts.Architecture.Services.Factories.UI;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Audio;
using Assets.Scripts.Boosters;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Tower.Selection
{
    public class SelectTowerButton : MonoBehaviour
    {
        [SerializeField] private TowerSelectionButtonHolder _buttonHolder;
        [SerializeField] private Button _button;

        private TowerSelection _towerSelection;
        private IAudioService _audioService;
        private IUIFactory _uiFactory;

        [Inject]
        public void Construct(IAudioService audioService, IUIFactory uiFactory)
        {
            _audioService = audioService;
            _uiFactory = uiFactory;
        }

        private void Awake()
        {
            _button.onClick.AddListener(OnButtonClickHandler);
            _towerSelection = GetComponentInParent<TowerSelection>();
        }

        private void Select() =>
            _towerSelection.ChangeSelection(_buttonHolder);

        private void Deselect(TowerSelectionButtonHolder button) =>
            _towerSelection.ChangeSelection(null);

        private void OnButtonClickHandler()
        {
            if (CheckIsBoosterNotActivated())
                return;

            _audioService.PlaySfx(SfxType.Click);

            if (_towerSelection.SelectedButton == null)
            {
                Select();
            }
            else if (_towerSelection.SelectedButton != null & _towerSelection.SelectedButton.Tower.TowerType != _buttonHolder.Tower.TowerType)
            {
                Deselect(_buttonHolder);
                Select();
            }
            else if (_towerSelection.SelectedButton != null & _towerSelection.SelectedButton.Tower.TowerType == _buttonHolder.Tower.TowerType)
            {
                Deselect(_buttonHolder);
            }
        }

        private bool CheckIsBoosterNotActivated()
        {
            foreach (BoosterButton boosterButton in _uiFactory.BoosterHolder.BoosterButtons)
            {
                if (boosterButton.IsActivated)
                    return true;
            }

            return false;
        }
    }
}