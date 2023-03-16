using UnityEngine;

public class CreateTower : MonoBehaviour
{
    [SerializeField] private CoinSystem _coinSystem;
    [SerializeField] private TowerPrice _towerPrice;

    [SerializeField] private GameObject _mageTower;
    [SerializeField] private GameObject _cannonTower;
    [SerializeField] private GameObject _megaTower;
    [SerializeField] private GameObject _speedTower;
  
    public void TowerCreation(TowerType towerType, Transform position)
    {
        switch (towerType)
        {
            case TowerType.Mage:
                if (_coinSystem.CoinForLvl > _towerPrice.MageTowerPrice)               
                    Instantiate(_mageTower, position);                             
                break;
            case TowerType.Cannon:
                if (_coinSystem.CoinForLvl > _towerPrice.CannonTowerPrice)
                    Instantiate(_cannonTower, position);
                break;
            case TowerType.Mega:
                if (_coinSystem.CoinForLvl > _towerPrice.MegaTowerPrice)
                    Instantiate(_megaTower, position);
                break;
            case TowerType.Speed:
                if (_coinSystem.CoinForLvl > _towerPrice.SpeedTowerPrice)
                    Instantiate(_speedTower, position);
                break;
        }
    }
}
