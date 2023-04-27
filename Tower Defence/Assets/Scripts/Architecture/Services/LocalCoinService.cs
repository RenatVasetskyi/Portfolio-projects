using System;
using Assets.Scripts.Architecture.Services.Interfaces;

namespace Assets.Scripts.Architecture.Services
{
    public class LocalCoinService : ILocalCoinService
    {
        public event Action OnCoinsChanged;

        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;

        public int Coins { get; set; }

        public LocalCoinService(ICurrentLevelSettingsProvider currentLevelSettingsProvider) =>
            _currentLevelSettingsProvider = currentLevelSettingsProvider;

        public void Buy(int price)
        {
            Coins -= price;
            OnCoinsChanged?.Invoke();
        }

        public void SetCoins() => 
            Coins = _currentLevelSettingsProvider.GetCurrentLevelSettings().Coins;
    }
}