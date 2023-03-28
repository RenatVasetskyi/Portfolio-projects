using UnityEngine;

public class TowerCreation : MonoBehaviour, ICreateTower
{
    public Material TowerMaterial;

    [SerializeField] private GameObject _mageTower;
    [SerializeField] private GameObject _cannonTower;
    [SerializeField] private GameObject _megaTower;
    [SerializeField] private GameObject _speedTower;   

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
                    Instantiate(_mageTower, position, Quaternion.identity, _towerParent);
                    EventManager.SendTowerSpawned();
                    EventManager.SendBoughtTower(_towerPrice.MageTowerPrice);
                }
                else
                {
                    EventManager.SendNotEnoughMoney();
                }
                break;
            case TowerType.Cannon:
                if (_coinSystem.Coins >= _towerPrice.CannonTowerPrice)
                {
                    Instantiate(_cannonTower, position, Quaternion.identity, _towerParent);
                    EventManager.SendTowerSpawned();
                    EventManager.SendBoughtTower(_towerPrice.CannonTowerPrice);
                }
                else
                {
                    EventManager.SendNotEnoughMoney();
                }
                break;
            case TowerType.Mega:
                if (_coinSystem.Coins >= _towerPrice.MegaTowerPrice)
                {
                    Instantiate(_megaTower, position, Quaternion.identity, _towerParent);
                    EventManager.SendTowerSpawned();
                    EventManager.SendBoughtTower(_towerPrice.MegaTowerPrice);
                }
                else
                {
                    EventManager.SendNotEnoughMoney();
                }
                break;
            case TowerType.Speed:
                if (_coinSystem.Coins >= _towerPrice.SpeedTowerPrice)
                {
                    Instantiate(_speedTower, position, Quaternion.identity, _towerParent);
                    EventManager.SendTowerSpawned();
                    EventManager.SendBoughtTower(_towerPrice.SpeedTowerPrice);
                }
                else
                {
                    EventManager.SendNotEnoughMoney();
                }
                break;
        }
    }
}
