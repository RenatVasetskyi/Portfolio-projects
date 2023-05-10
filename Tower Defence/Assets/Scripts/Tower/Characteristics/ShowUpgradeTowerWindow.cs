using Assets.Scripts.Architecture.Services.Factories.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using Vector2 = UnityEngine.Vector2;

namespace Assets.Scripts.Tower.Characteristics
{
    public class ShowUpgradeTowerWindow : MonoBehaviour
    {
        [SerializeField] private TowerCharacteristics _towerCharacteristics;

        private float _windowScaleDuration = 0.3f;
        private bool _isUpgrageWindowOpened = false;

        private IUIFactory _uiFactory;

        private UpgradeTowerWindow _window;

        [Inject]
        public void Construct(IUIFactory uiFactory) =>
            _uiFactory = uiFactory;

        public void CloseWindow()
        {
            _isUpgrageWindowOpened = false;
            LeanTween.scale(_window.gameObject, Vector3.zero, _windowScaleDuration)
                .setOnComplete(DestroyWindow);
        }

        private void OnMouseDown()
        {
            if (IsPointerOverUI())
                return;

            if (_uiFactory.TowerSelection.SelectedButton != null) 
                return;                

            if (_isUpgrageWindowOpened == false) 
                OpenWindow();
            else 
                CloseWindow();
        }

        private void OpenWindow()
        {
            _isUpgrageWindowOpened = true;
            _window = _uiFactory.CreateUpgradeTowerWindow(_uiFactory.LevelUIRoot, _towerCharacteristics);
            _window.CloseWindowButton.onClick.AddListener(CloseWindow);
            LeanTween.scale(_window.gameObject, Vector2.one, _windowScaleDuration);
        }

        private void DestroyWindow() => 
            Destroy(_window);

        private bool IsPointerOverUI()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return true;

            return false;
        }
    }
}
