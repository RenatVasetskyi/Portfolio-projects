using UnityEngine;
using Coins;
using Events;

namespace Tower
{
    public class TowerCreation : MonoBehaviour, ICreateTower
    {
        public ButtonCreator ButtonCreator;

        public Material TowerMaterial;

        [SerializeField] private Transform _towerParent;

        [SerializeField] private CoinOperations _coinOperations;

        public void CreateTower(Vector3 position, TowerType towerType)
        {
            if (_coinOperations.Coins >= ButtonCreator.SelectedButton.GetComponent<ButtonHolder>().Price)
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
}
