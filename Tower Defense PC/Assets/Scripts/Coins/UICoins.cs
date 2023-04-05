using System;
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
        _coinsText.text = _localCoinService.Coins.ToString();    
    }

    private void UpdateText()
    {
        _coinsText.text = _localCoinService.Coins.ToString();
    }
}
