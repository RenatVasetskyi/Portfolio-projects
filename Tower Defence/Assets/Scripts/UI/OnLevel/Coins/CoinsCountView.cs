using Assets.Scripts.Architecture.Services.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.OnLevel.Coins
{
    public class CoinsCountView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;

        private ILocalCoinService _localCoinService;

        [Inject]
        public void Construct(ILocalCoinService localCoinService) =>
            _localCoinService = localCoinService;

        private void Start()
        {
            _localCoinService.OnCoinsChanged += UpdateCoins;
            UpdateCoins();
        }

        private void OnDestroy() =>
            _localCoinService.OnCoinsChanged -= UpdateCoins;

        private void UpdateCoins() =>
            _coinsText.text = _localCoinService.Coins.ToString();
    }
}