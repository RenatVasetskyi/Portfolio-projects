using Assets.Scripts.Architecture.Services.Factories.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.Scripts.Boosters.Meteorite
{
    public class MeteorCrosshairDisplayer : MonoBehaviour
    {
        [SerializeField] private BoosterButton _boosterButton;

        private IUIFactory _uiFactory;

        private Ray _ray;
        private Vector3 _screenPosition;

        private bool _isCrosshairVisible = false;

        private UnityEngine.Camera _camera;

        [Inject]
        public void Construct(IUIFactory uiFactory) =>
            _uiFactory = uiFactory;

        private void Awake() =>
            _camera = UnityEngine.Camera.main;

        private void LateUpdate()
        {
            if (_boosterButton.IsActivated == false)
                return;

            if (_isCrosshairVisible == false)
            {
                _isCrosshairVisible = true;
                Show();
            }
            else
                MoveCrosshair(GetWorldPosition());
        }

        private void MoveCrosshair(Vector3 position) =>
            _uiFactory.MeteorCrosshair.transform.position = position;

        private Vector3 GetWorldPosition()
        {
            _screenPosition = GetScreenPosition();
            _ray = _camera.ScreenPointToRay(_screenPosition);

            if (Physics.Raycast(_ray, out RaycastHit hit))
                return hit.point;

            return Vector3.zero;
        }

        private void Show() =>
            _uiFactory.CreateMeteorCrosshair();

        private void Hide() =>
            Destroy(_uiFactory.MeteorCrosshair);

        private Vector2 GetScreenPosition() =>
            Mouse.current.position.ReadValue();
    }
}