using UnityEngine;
using Coins;
using MyEvents;

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
                Events.SendBoughtTower(ButtonCreator.SelectedButton.GetComponent<ButtonHolder>().Price);
            }
            else
            {
                Events.SendNotEnoughMoney();
            }
        }
    }
}
