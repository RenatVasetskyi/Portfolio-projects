using MyEvents;
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

            Events.OnBoughtTower.AddListener(_coinOperations.BuyTower);
            Events.OnTowerUpgraded.AddListener(_coinOperations.UpgradeTower);
            Events.OnEnemyKilled.AddListener(_coinOperations.GetBonus);
        }
    }
}
