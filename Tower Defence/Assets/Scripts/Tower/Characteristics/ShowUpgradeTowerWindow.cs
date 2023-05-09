using Assets.Scripts.Architecture.Services.Factories.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.Scripts.Tower.Characteristics
{
    public class ShowUpgradeTowerWindow : MonoBehaviour
    {
        [SerializeField] private TowerCharacteristics _towerCharacteristics;
        [SerializeField] private Vector3 _windowScale;

        private float _windowScaleDuration = 0.3f;

        private bool _isUpgrageWindowOpened = false;

        private IUIFactory _uiFactory;

        private UpgradeTowerWindow _window;

        [Inject]
        public void Construct(IUIFactory uiFactory) =>
            _uiFactory = uiFactory;

        public void CloseWindow()
        {
            LeanTween.scale(_window.gameObject, Vector3.zero, _windowScaleDuration)
                .setOnComplete(DestroyWindow);
        }

        private void OnMouseDown()
        {
            if (IsPointerOverUI())
                return;

            if (_isUpgrageWindowOpened == false)
            {
                _isUpgrageWindowOpened = true;
                OpenWindow();
            }
            else
            {
                _isUpgrageWindowOpened = false;
                CloseWindow();
            }
        }

        private void OpenWindow()
        {
            _window = _uiFactory.CreateUpgradeTowerWindow(_uiFactory.LevelUIRoot, _towerCharacteristics);
            LeanTween.scale(_window.gameObject, _windowScale, _windowScaleDuration);
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
