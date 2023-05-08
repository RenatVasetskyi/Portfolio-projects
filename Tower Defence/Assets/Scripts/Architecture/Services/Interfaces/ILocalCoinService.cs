using System;

namespace Assets.Scripts.Architecture.Services.Interfaces
{
    public interface ILocalCoinService
    { 
        event Action OnCoinsChanged;
        int Coins { get; }
        void Buy(int price);
        void SetCoins();
        void GetBonus(int bonus);
    }
}