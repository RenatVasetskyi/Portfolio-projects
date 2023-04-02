using TMPro;
using UnityEngine;

namespace Coins
{
    public class CoinOperations : MonoBehaviour, IUpdateText, ICoinOperations
    {
        public float Coins;

        [SerializeField] private TextMeshProUGUI _coinsText;

        public void UpdateText()
        {
            _coinsText.text = Coins.ToString();
        }

        public void BuyTower(int price)
        {
            Coins -= price;
            UpdateText();
        }

        public void UpgradeTower(float price)
        {
            Mathf.Round(Coins -= price);
            UpdateText();
        }

        public void GetBonus()
        {
            Coins += 15;
            UpdateText();
        }       
    }
}
