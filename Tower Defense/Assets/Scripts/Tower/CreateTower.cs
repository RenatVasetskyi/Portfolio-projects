using UnityEngine;

public class CreateTower : MonoBehaviour
{
    [SerializeField] private GameObject _mageTower;
    [SerializeField] private GameObject _cannonTower;
    [SerializeField] private GameObject _megaTower;
    [SerializeField] private GameObject _speedTower;
  
    private void TowerCreation(TowerType towerType, Transform position)
    {
        switch (towerType)
        {
            case TowerType.Mage:              
                Instantiate(_mageTower, position);
                break;
            case TowerType.Cannon:
                Instantiate(_cannonTower, position);
                break;
            case TowerType.Mega:
                Instantiate(_megaTower, position);
                break;
            case TowerType.Speed:
                Instantiate(_speedTower, position);
                break;
        }
    }
}
