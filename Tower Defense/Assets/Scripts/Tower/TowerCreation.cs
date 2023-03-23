using UnityEngine;

public class TowerCreation : MonoBehaviour
{
    public GameObject MageTower;
    public GameObject CannonTower;
    public GameObject MegaTower;
    public GameObject SpeedTower;

    [SerializeField] private Transform _towerParent;

    [SerializeField] private CoinSystem _coinSystem;
    [SerializeField] private TowerPrice _towerPrice;

    public void CreateTower(Vector3 position, TowerType towerType)
    {
        switch (towerType)
        {
            case TowerType.Mage:
                if (_coinSystem.Coins >= _towerPrice.MageTowerPrice)
                {                                                        
                    Instantiate(MageTower, position, Quaternion.identity, _towerParent);                                       
                    EventManager.SendTowerSpawned();
                    EventManager.SendBoughtTower(_towerPrice.MageTowerPrice);
                }
                break;
            case TowerType.Cannon:
                if (_coinSystem.Coins >= _towerPrice.CannonTowerPrice)
                {                                      
                    Instantiate(CannonTower, position, Quaternion.identity, _towerParent);
                    EventManager.SendTowerSpawned();
                    EventManager.SendBoughtTower(_towerPrice.CannonTowerPrice);
                }
                break;
            case TowerType.Mega:
                if (_coinSystem.Coins >= _towerPrice.MegaTowerPrice)
                {                                    
                    Instantiate(MegaTower, position, Quaternion.identity, _towerParent);
                    EventManager.SendTowerSpawned();
                    EventManager.SendBoughtTower(_towerPrice.MegaTowerPrice);
                }
                break;
            case TowerType.Speed:
                if (_coinSystem.Coins >= _towerPrice.SpeedTowerPrice)
                {                                                         
                    Instantiate(SpeedTower, position, Quaternion.identity, _towerParent);                  
                    EventManager.SendTowerSpawned();
                    EventManager.SendBoughtTower(_towerPrice.SpeedTowerPrice);
                }
                break;
        }
    }
}
