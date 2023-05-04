using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Tower.Selection
{
    public class SelectTowerButton : MonoBehaviour
    {
        [SerializeField] private TowerSelectionButtonHolder _button;
        private TowerSelection _towerSelection;

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