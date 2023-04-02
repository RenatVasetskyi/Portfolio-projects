using Events;
using UnityEngine;

namespace Coins
{
    public class CoinSystem : MonoBehaviour
    {
        private ICoinOperations _coinOperations;
        private IUpdateText _updateText;

        private void Awake()
        {
            _coinOperations = GetComponent<ICoinOperations>();
            _updateText = GetComponent<IUpdateText>();

            _updateText.UpdateText();

            EventManager.BoughtTower.AddListener(_coinOperations.BuyTower);
            EventManager.TowerUpgraded.AddListener(_coinOperations.UpgradeTower);
            EventManager.EnemyDestroyed.AddListener(_coinOperations.GetBonus);
        }
    }
}
