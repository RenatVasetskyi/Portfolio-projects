using Assets.Scripts.Architecture.Services;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;

        private ICoinService _coinService;

        private void Awake()
        {
            _coinService = AllServices.Container.Single<ICoinService>();
            _coinService.OnCoinsChanged += UpdateText;
            UpdateText();
        }

        private void UpdateText() =>
            _coinsText.text = _coinService.Coins.ToString();
    }
}