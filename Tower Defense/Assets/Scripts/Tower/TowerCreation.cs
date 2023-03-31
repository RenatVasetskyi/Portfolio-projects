using UnityEngine;

public class TowerCreation : MonoBehaviour, ICreateTower
{
    public ButtonCreator ButtonCreator;

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
        if (_coinSystem.Coins >= ButtonCreator.SelectedButton.GetComponent<ButtonHolder>().Price)
        {
            Instantiate(ButtonCreator.SelectedButton.GetComponent<ButtonHolder>().TowerPrefab, position, Quaternion.identity, _towerParent);
            EventManager.SendTowerSpawned();
            EventManager.SendBoughtTower(ButtonCreator.SelectedButton.GetComponent<ButtonHolder>().Price);
        }
        else
        {
            EventManager.SendNotEnoughMoney();
        }
    }
}
