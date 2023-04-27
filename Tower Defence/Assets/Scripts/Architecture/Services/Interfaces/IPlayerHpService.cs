using System;

namespace Assets.Scripts.Architecture.Services.Interfaces
{
    public interface IPlayerHpService
    {
        event Action OnHpChanged;
        int Hp { get; set; }
        void SetHp();
        void TakeDamage(int damage);
    }
}