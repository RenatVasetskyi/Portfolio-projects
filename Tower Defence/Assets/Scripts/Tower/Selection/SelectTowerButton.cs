using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Tower.Selection
{
    public class SelectTowerButton : MonoBehaviour
    {
        [SerializeField] private TowerSelectionButtonHolder _button;

        private TowerSelection _towerSelection;
        private IAudioService _audioService;

        [Inject]
        public void Construct(IAudioService audioService) =>
            _audioService = audioService;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnButtonClickHandler);
            _towerSelection = GetComponentInParent<TowerSelection>();
        }

        private void Select() =>
            _towerSelection.ChangeSelection(_button);

        private void Deselect(TowerSelectionButtonHolder button) =>
            _towerSelection.ChangeSelection(null);

        private void OnButtonClickHandler()
        {
            _audioService.PlaySfx(SfxType.Click);

            if (_towerSelection.SelectedButton == null)
            {
                Select();
            }
            else if (_towerSelection.SelectedButton != null & _towerSelection.SelectedButton.Tower.TowerType != _button.Tower.TowerType)
            {
                Deselect(_button);
                Select();
            }
            else if (_towerSelection.SelectedButton != null & _towerSelection.SelectedButton.Tower.TowerType == _button.Tower.TowerType)
            {
                Deselect(_button);
            }
        }
    }
}