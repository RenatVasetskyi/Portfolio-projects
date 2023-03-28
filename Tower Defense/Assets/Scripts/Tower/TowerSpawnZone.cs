using UnityEngine;

public class TowerSpawnZone : MonoBehaviour, ICheckSpawnZone
{
    [SerializeField] private LayerMask _spawnZoneLayer;
    [SerializeField] private TowerSelection _towerSelection;

    private Ray _ray;

    private TowerCreation _towerCreation;

    private Vector3 _screenPosition;
    private Vector3 _worldPosition;

    private int _maxRaycastDistance = 100;

    private Material _towerMaterial;

    public void ShowTower(RaycastHit hit)
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

    public RaycastHit CheckZone()
    {
        if (!Physics.Raycast(_ray, out RaycastHit hit, _maxRaycastDistance, _spawnZoneLayer))
        {
            return default;
        }
        else
        {
            return hit;
        }
    }

    public void ChangeTowerColor()
    {
        if (Physics.Raycast(_ray, _maxRaycastDistance, _spawnZoneLayer))
            _towerMaterial.color = Color.green;
        else
            _towerMaterial.color = Color.red;
    }

    private void Start()
    {
        _towerCreation = GetComponentInParent<TowerCreation>();
        _towerMaterial = _towerCreation.TowerMaterial;
    }

    private void LateUpdate()
    {
        _screenPosition = Input.mousePosition;

        _ray = Camera.main.ScreenPointToRay(_screenPosition);

        ChangeTowerColor();
    }

    private void OnMouseDown()
    {
        RaycastHit hit = CheckZone();
        ShowTower(hit);      
    }
}
