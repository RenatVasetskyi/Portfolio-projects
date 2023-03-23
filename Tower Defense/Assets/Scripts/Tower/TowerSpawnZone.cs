using UnityEngine;

public class TowerSpawnZone : MonoBehaviour
{   
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private TowerSelection _towerSelection; 
    
    private TowerCreation _towerCreation;

    private Vector3 _screenPosition;
    private Vector3 _worldPosition;

    private int _maxRaycastDistance = 100;

    public GameObject tower;

    private void Update()
    {
        _screenPosition = Input.mousePosition;
    }

    private void Start()
    {
        _towerCreation = GetComponentInParent<TowerCreation>();
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(_screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _maxRaycastDistance, _layerMask))
        {
            _worldPosition = hit.point;

            if (_towerSelection.IsMageTowerButtonPressed == true)
            {
                _towerCreation.CreateTower(_worldPosition, TowerType.Mage);              
            }
            else if (_towerSelection.IsCannonTowerButtonPressed == true)
            {
                _towerCreation.CreateTower(_worldPosition, TowerType.Cannon);
            }
            else if (_towerSelection.IsMegaTowerButtonPressed == true)
            {
                _towerCreation.CreateTower(_worldPosition, TowerType.Mega);
            }
            else if (_towerSelection.IsSpeedTowerButtonPressed == true)
            {
                _towerCreation.CreateTower(_worldPosition, TowerType.Speed);
            }
        }
    }
}
