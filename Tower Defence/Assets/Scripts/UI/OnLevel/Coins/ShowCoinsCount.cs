using Assets.Scripts.Architecture.Services.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.OnLevel.Coins
{
    public class ShowCoinsCount : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;

        private ILocalCoinService _localCoinService;

        [Inject]
        public void Construct(ILocalCoinService localCoinService) => 
            _localCoinService = localCoinService;

        private void Start()
        {
            _localCoinService.OnCoinsChanged += UpdateText;
            UpdateText();
        }

        private void OnDestroy() =>
            _localCoinService.OnCoinsChanged -= UpdateText;

        private void UpdateText() =>
            _coinsText.text = _localCoinService.Coins.ToString();
    }
}