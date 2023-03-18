using UnityEngine;

public class TowerCreation : MonoBehaviour
{
    public bool IsMageTowerButtonPressed = false;
    public bool IsCannonTowerButtonPressed = false;
    public bool IsMegaTowerButtonPressed = false;
    public bool IsSpeedTowerButtonPressed = false;

    [SerializeField] private Transform _towerParent;

    [SerializeField] private CoinSystem _coinSystem;
    [SerializeField] private TowerPrice _towerPrice;

    [SerializeField] private GameObject _mageTower;
    [SerializeField] private GameObject _cannonTower;
    [SerializeField] private GameObject _megaTower;
    [SerializeField] private GameObject _speedTower; 

    public void CreateTower(TowerType towerType)
    {
        switch (towerType)
        {
            case TowerType.Mage:
                if (_coinSystem.Coins >= _towerPrice.MageTowerPrice)
                {                                                        
                    Instantiate(_mageTower, transform.position, Quaternion.identity, _towerParent);                    
                    Destroy(gameObject);                   
                    EventManager.SendTowerSpawned();
                    EventManager.SendBoughtTower(_towerPrice.MageTowerPrice);
                }
                break;
            case TowerType.Cannon:
                if (_coinSystem.Coins >= _towerPrice.CannonTowerPrice)
                {                                      
                    Instantiate(_cannonTower, transform.position, Quaternion.identity, _towerParent);
                    Destroy(gameObject);
                    EventManager.SendTowerSpawned();
                    EventManager.SendBoughtTower(_towerPrice.CannonTowerPrice);
                }
                break;
            case TowerType.Mega:
                if (_coinSystem.Coins >= _towerPrice.MegaTowerPrice)
                {                                    
                    Instantiate(_megaTower, transform.position, Quaternion.identity, _towerParent);
                    Destroy(gameObject);
                    EventManager.SendTowerSpawned();
                    EventManager.SendBoughtTower(_towerPrice.MegaTowerPrice);
                }
                break;
            case TowerType.Speed:
                if (_coinSystem.Coins >= _towerPrice.SpeedTowerPrice)
                {                                                         
                    Instantiate(_speedTower, transform.position, Quaternion.identity, _towerParent);
                    Destroy(gameObject);                  
                    EventManager.SendTowerSpawned();
                    EventManager.SendBoughtTower(_towerPrice.SpeedTowerPrice);
                }
                break;
        }
    }

    private void OnMouseDown()
    {
        if (IsMageTowerButtonPressed == true)
        {
            CreateTower(TowerType.Mage);
        }
        else if (IsCannonTowerButtonPressed == true)
        {
            CreateTower(TowerType.Cannon);
        }
        else if (IsMegaTowerButtonPressed == true)
        {
            CreateTower(TowerType.Mega);
        }
        else if (IsSpeedTowerButtonPressed == true)
        {
            CreateTower(TowerType.Speed);
        }
    }
}
