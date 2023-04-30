using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Tower.Spawn
{
    public class SpawnZoneChecker
    {
        [SerializeField] private LayerMask _spawnZoneLayer;
        [SerializeField] private LayerMask _towerLayer;

        private Ray _ray;
        private int _maxRaycastDistance = 200;

        private Vector2 _mousePosition;

        public RaycastHit CheckAccess()
        {
            GetMousePosition();

            if (Physics.Raycast(_ray, out RaycastHit hit, _maxRaycastDistance, _spawnZoneLayer) & !Physics.Raycast(_ray, _maxRaycastDistance, _towerLayer))
                return hit;
            else
                return default;
        }

        private void GetMousePosition()
        {
            _mousePosition = Mouse.current.position.ReadValue();
            _ray = UnityEngine.Camera.main.ScreenPointToRay(_mousePosition);
        }
    }
}