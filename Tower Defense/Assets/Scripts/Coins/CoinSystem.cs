using TMPro;
using UnityEngine;
using Events;

namespace Coins
{
    public class CoinSystem : MonoBehaviour
    {
        public float Coins;

        [SerializeField] private TextMeshProUGUI _coinsText;

        private void Awake()
        {
            _coinsText.text = Coins.ToString();
            EventManager.BoughtTower.AddListener(BuyTower);
            EventManager.TowerUpgraded.AddListener(UpgradeTower);
            EventManager.EnemyDestroyed.AddListener(GetBonus);
        }

        private void BuyTower(int price)
        {
            Coins -= price;
            UpdateCoinsText();
        }

        private void UpgradeTower(float price)
        {
            Mathf.Round(Coins -= price);
            UpdateCoinsText();
        }

        private void GetBonus()
        {
            Coins += 15;
            UpdateCoinsText();
        }

        private void UpdateCoinsText()
        {
            _coinsText.text = Coins.ToString();
        }
    }
}
