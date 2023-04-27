using System;
using Assets.Scripts.Architecture.Services.Interfaces;

namespace Assets.Scripts.Architecture.Services
{
    public class PlayerHpService : IPlayerHpService
    {
        public event Action OnHpChanged;

        private readonly ICurrentLevelSettingsProvider _levelSettingsProvider;
    
        public int Hp { get; set; }

        public PlayerHpService(ICurrentLevelSettingsProvider levelSettingsProvider) =>
            _levelSettingsProvider = levelSettingsProvider;

        public void SetHp() => 
            Hp = _levelSettingsProvider.GetCurrentLevelSettings().Hp;

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            OnHpChanged?.Invoke();
        }
    }
}