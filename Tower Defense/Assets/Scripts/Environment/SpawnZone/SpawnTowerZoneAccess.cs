using UnityEngine;
using Tower;

namespace Environment
{
    public class SpawnTowerZoneAccess : MonoBehaviour, ISpawnZone
    {
        [SerializeField] private ButtonCreator _buttonCreator;

        [SerializeField] private LayerMask _environmentLayer;

        [SerializeField] private GameObject _mageTowerModel;
        [SerializeField] private GameObject _cannonTowerModel;
        [SerializeField] private GameObject _megaTowerModel;
        [SerializeField] private GameObject _speedTowerModel;

        [SerializeField] private Material _towerMaterial;

        private Vector3 _screenPosition;
        private Vector3 _worldPosition;

        private int _maxRaycastDistance = 200;

        private GameObject _spawnedModel;
        private bool _isTowerModelSpawned = false;

        public void CheckAccess()
        {
            _screenPosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(_screenPosition);

            if (Physics.Raycast(ray, out RaycastHit hit, _maxRaycastDistance, _environmentLayer))
            {
                _worldPosition = hit.point;

                if (_buttonCreator.SelectedButton != null)
                {
                    if (_isTowerModelSpawned == false)
                    {
                        _isTowerModelSpawned = true;
                        _spawnedModel = Instantiate(_buttonCreator.SelectedButton.GetComponent<ButtonHolder>().TowerModel);
                    }
                    else
                    {
                        _spawnedModel.transform.position = _worldPosition;
                    }
                }
                else
                {
                    _isTowerModelSpawned = false;
                    Destroy(_spawnedModel);
                }
            }           
        }
    }
}