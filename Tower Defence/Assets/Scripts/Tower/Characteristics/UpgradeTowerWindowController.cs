using Assets.Scripts.Architecture.Services.Factories.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.Scripts.Tower.Characteristics
{
    public class UpgradeTowerWindowController : MonoBehaviour
    {
        [SerializeField] private TowerCharacteristics _towerCharacteristics;
        private UpgradeTowerWindowView _window;

        private bool _isUpgrageWindowOpened = false;

        private IUIFactory _uiFactory;

        [Inject]
        public void Construct(IUIFactory uiFactory) =>
            _uiFactory = uiFactory;

        private void OnMouseDown()
        {
            if (IsPointerOverUI())
                return;

            if (_uiFactory.TowerSelection.SelectedButton != null) 
                return;

            if (_isUpgrageWindowOpened == false)
                ShowWindow();
            else
                _window.Hide(out _isUpgrageWindowOpened);
        }

        private void ShowWindow()
        {
            _window = _uiFactory.CreateUpgradeTowerWindow(_uiFactory.LevelUIRoot);

            _window.TowerCharacteristics = _towerCharacteristics;

            _window.UpgradeButton.onClick.AddListener(_towerCharacteristics.Upgrade);
            _window.CloseWindow.onClick.AddListener(HideWindow);
            _window.TowerCharacteristics.OnTowerCharacteristicsUpgraded += _window.UpdateCharacteristics;

            _window.UpdateCharacteristics();
            _window.Show(out _isUpgrageWindowOpened,Mouse.current.position.ReadValue());
        }

        private void HideWindow() =>
            _window.Hide(out _isUpgrageWindowOpened);

        private bool IsPointerOverUI()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return true;

            return false;
        }
    }
}
