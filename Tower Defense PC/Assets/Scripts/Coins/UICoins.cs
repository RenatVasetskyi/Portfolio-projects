using TMPro;
using UnityEngine;
using Zenject;

public class UICoins : MonoBehaviour
{   
    private TextMeshProUGUI _coinsText;
    private LocalCoinService _localCoinService;

    [Inject]
    private void Construct(LocalCoinService localCoinService)
    {
        _localCoinService = localCoinService;
        _coinsText = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    private void Start()
    {
        _localCoinService.OnCoinsChanged += UpdateText;
    }

    private void OnDestroy()
    {
        _localCoinService.OnCoinsChanged -= UpdateText;
    }

    private void UpdateText()
    {
        _coinsText.text = _localCoinService.Coins.ToString();
    }
}
