using TMPro;
using UnityEngine;

public class TowerPrice : MonoBehaviour
{
    public int MageTowerPrice = 60;
    public int CannonTowerPrice = 50;   
    public int MegaTowerPrice = 70;
    public int SpeedTowerPrice = 80;

    [SerializeField] private TextMeshProUGUI _mageTowerPriceText;
    [SerializeField] private TextMeshProUGUI _cannonTowerPriceText;
    [SerializeField] private TextMeshProUGUI _megaTowerPriceText;
    [SerializeField] private TextMeshProUGUI _speedTowerPriceText;

    private void Awake()
    {
        _mageTowerPriceText.text = MageTowerPrice.ToString();
        _cannonTowerPriceText.text = CannonTowerPrice.ToString();
        _megaTowerPriceText.text = MegaTowerPrice.ToString();
        _speedTowerPriceText.text = SpeedTowerPrice.ToString();
    }
}
