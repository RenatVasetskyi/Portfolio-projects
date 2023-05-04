using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Tower.Spawn
{
    public class SpawnZoneChecker
    { 
        private LayerMask _spawnZoneLayer = 1<<6;
        private LayerMask _towerLayer = 1<<7;

        private Ray _ray;
        private int _maxRaycastDistance = 200;

        private Vector2 _mousePosition;

        public RaycastHit CheckAccess()
        {
            InitRay();

            if (Physics.Raycast(_ray, out RaycastHit hit, _maxRaycastDistance, _spawnZoneLayer) &&
                !Physics.Raycast(_ray, _maxRaycastDistance, _towerLayer))
                return hit;
            else
                return default;
        }

        private void InitRay()
        {
            _mousePosition = Mouse.current.position.ReadValue();
            _ray = UnityEngine.Camera.main.ScreenPointToRay(_mousePosition);
        }
    }
}