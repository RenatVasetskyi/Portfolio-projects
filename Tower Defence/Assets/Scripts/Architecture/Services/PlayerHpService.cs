using System;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Audio;

namespace Assets.Scripts.Architecture.Services
{
    public class PlayerHpService : IPlayerHpService
    {
        private readonly ICurrentLevelSettingsProvider _levelSettingsProvider;
        private readonly IStateMachine _stateMachine;
        private readonly IAudioService _audioService;

        public event Action OnHpChanged;
    
        public int Hp { get; set; }

        public PlayerHpService(ICurrentLevelSettingsProvider levelSettingsProvider, IStateMachine stateMachine, IAudioService audioService)
        {
            _levelSettingsProvider = levelSettingsProvider;
            _stateMachine = stateMachine;
            _audioService = audioService;
        }

        public void SetHp() => 
            Hp = _levelSettingsProvider.GetCurrentLevelSettings().Hp;

        public void TakeDamage(int damage)
        {
            _audioService.PlaySfx(SfxType.PlayerGetsDamage);
            Hp -= damage;
            OnHpChanged?.Invoke();
            if (Hp <= 0)
                _stateMachine.Enter<GameOverState>();
        }
    }
}