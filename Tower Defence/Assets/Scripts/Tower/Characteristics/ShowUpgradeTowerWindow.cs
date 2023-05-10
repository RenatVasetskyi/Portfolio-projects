using Assets.Scripts.Architecture.Services.Factories.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.Scripts.Tower.Characteristics
{
    public class ShowUpgradeTowerWindow : MonoBehaviour
    {
        [SerializeField] private TowerCharacteristics _towerCharacteristics;

        private bool _isUpgrageWindowOpened = false;

        private IUIFactory _uiFactory;

        private UpgradeTowerWindow _window;

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
            _window = _uiFactory.CreateUpgradeTowerWindow(_uiFactory.LevelUIRoot, _towerCharacteristics);
            _window.Show(out _isUpgrageWindowOpened);
        }

        private bool IsPointerOverUI()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return true;

            return false;
        }
    }
}
