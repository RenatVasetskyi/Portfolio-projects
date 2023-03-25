using TMPro;
using UnityEngine;

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
        _coinsText.text = Coins.ToString();
    }

    private void UpgradeTower(float price)
    {
        Mathf.Round(Coins -= price);
        _coinsText.text = Coins.ToString();
    }

    private void GetBonus()
    {
        Coins += 15;
        _coinsText.text = Coins.ToString();
    }
}
