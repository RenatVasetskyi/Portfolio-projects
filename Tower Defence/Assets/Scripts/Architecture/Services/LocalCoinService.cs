using System;
using Assets.Scripts.Architecture.Services.Interfaces;

namespace Assets.Scripts.Architecture.Services
{
    public class LocalCoinService : ILocalCoinService
    {
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingsProvider;

        public event Action OnCoinsChanged;

        public int Coins { get; private set; }

        public LocalCoinService(ICurrentLevelSettingsProvider currentLevelSettingsProvider) =>
            _currentLevelSettingsProvider = currentLevelSettingsProvider;

        public void Buy(int price)
        {
            Coins -= price;
            OnCoinsChanged?.Invoke();
        }

        public void GetBonus(int bonus)
        {
            Coins += bonus;
            OnCoinsChanged?.Invoke();
        }

        public void SetCoins() => 
            Coins = _currentLevelSettingsProvider.GetCurrentLevelSettings().Coins;
    }
}