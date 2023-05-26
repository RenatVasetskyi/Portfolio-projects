using System;

namespace Assets.Scripts.Architecture.Services
{
    public class CoinService : ICoinService
    {
        public event Action OnCoinsChanged;
        public int Coins { get; private set; }

        public void GetBonus(int bonus)
        {
            Coins += bonus;
            OnCoinsChanged?.Invoke();
        }

        public void ResetCoins() =>
            Coins = 0;
    }
}