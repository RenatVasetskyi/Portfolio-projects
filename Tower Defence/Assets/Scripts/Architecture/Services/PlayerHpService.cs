using System;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;

namespace Assets.Scripts.Architecture.Services
{
    public class PlayerHpService : IPlayerHpService
    {
        private readonly ICurrentLevelSettingsProvider _levelSettingsProvider;
        private readonly IStateMachine _stateMachine;

        public event Action OnHpChanged;
    
        public int Hp { get; set; }

        public PlayerHpService(ICurrentLevelSettingsProvider levelSettingsProvider, IStateMachine stateMachine)
        {
            _levelSettingsProvider = levelSettingsProvider;
            _stateMachine = stateMachine;
        }

        public void SetHp() => 
            Hp = _levelSettingsProvider.GetCurrentLevelSettings().Hp;

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            OnHpChanged?.Invoke();
            if (Hp <= 0)
                _stateMachine.Enter<GameOverState>();
        }
    }
}