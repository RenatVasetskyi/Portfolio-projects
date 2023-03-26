using UnityEngine;

public class InaccessibleSpawnTowerZone : MonoBehaviour
{
    [SerializeField] private TowerSelection _towerSelection;
    [SerializeField] private TowerCreation _towerCreation;

    [SerializeField] private LayerMask _environmentLayer;

    [SerializeField] private GameObject _mageTowerModel;
    [SerializeField] private GameObject _cannonTowerModel;
    [SerializeField] private GameObject _megaTowerModel;
    [SerializeField] private GameObject _speedTowerModel;

    [SerializeField] private Material _towerMaterial;

    private Vector3 _screenPosition;
    private Vector3 _worldPosition;

    private int _maxRaycastDistance = 100;

    private bool _isMageTowerActive = false;
    private bool _isCannonTowerActive = false;
    private bool _isMegaTowerActive = false;
    private bool _isSpeedTowerActive = false;

    private void LateUpdate()
    {
        _screenPosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(_screenPosition);        

        if (Physics.Raycast(ray, out RaycastHit hit, _maxRaycastDistance, _environmentLayer))
        {
            _worldPosition = hit.point;
           
            if (_towerSelection.IsMageTowerButtonPressed == true)
            {
                if (_isMageTowerActive == false)
                {
                    _mageTowerModel = Instantiate(_mageTowerModel);
                    _isMageTowerActive = true;                              
                }
                else
                {
                    _mageTowerModel.transform.position = _worldPosition;
                }
            }
            else if (_towerSelection.IsCannonTowerButtonPressed == true)
            {
                if (_isCannonTowerActive == false)
                {
                    _cannonTowerModel = Instantiate(_cannonTowerModel);
                    _isCannonTowerActive = true;
                }
                else
                {
                    _cannonTowerModel.transform.position = _worldPosition;
                }
            }
            else if (_towerSelection.IsMegaTowerButtonPressed == true)
            {
                if (_isMegaTowerActive == false)
                {
                    _megaTowerModel = Instantiate(_megaTowerModel);
                    _isMegaTowerActive = true;
                }
                else
                {
                    _megaTowerModel.transform.position = _worldPosition;
                }
            }
            else if (_towerSelection.IsSpeedTowerButtonPressed == true)
            {
                if (_isSpeedTowerActive == false)
                {
                    _speedTowerModel = Instantiate(_speedTowerModel);
                    _isSpeedTowerActive = true;
                }
                else
                {
                    _speedTowerModel.transform.position = _worldPosition;
                }
            }
        }             
    }
}
