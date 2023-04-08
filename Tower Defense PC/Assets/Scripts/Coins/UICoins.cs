using System;
using TMPro;
using UnityEngine;
using Zenject;

public class UICoins : MonoBehaviour
{
    public Action OnCoinsChanged;

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
        OnCoinsChanged += UpdateText;
    }

    private void OnDestroy()
    {
        OnCoinsChanged -= UpdateText;
    }

    private void UpdateText()
    {
        _coinsText.text = _localCoinService.Coins.ToString();
    }
}
