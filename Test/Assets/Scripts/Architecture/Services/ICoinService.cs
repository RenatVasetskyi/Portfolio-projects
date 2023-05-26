using System;

namespace Assets.Scripts.Architecture.Services
{
    public interface ICoinService : IService
    {
        event Action OnCoinsChanged;
        int Coins { get; }
        void GetBonus(int bonus);
    }
}