using System;

namespace Assets.Scripts.Architecture.Services.Interfaces
{
    public interface ILocalCoinService
    { 
        event Action OnCoinsChanged;
        int Coins { get; set; }
        void Buy(int price);
    }
}