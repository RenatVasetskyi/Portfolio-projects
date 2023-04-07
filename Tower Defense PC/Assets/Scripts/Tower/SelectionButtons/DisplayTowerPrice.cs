using TMPro;
using UnityEngine;

public class DisplayTowerPrice : SelectTower
{
    [SerializeField] private TextMeshProUGUI _priceText;

    private void Start()
    {      
        DisplayPrice();
    }

    private void DisplayPrice()
    {
        _priceText.text = _buttonHolder.Tower.Price.ToString();
    }
}
