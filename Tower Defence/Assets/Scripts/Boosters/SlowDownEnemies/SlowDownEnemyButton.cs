using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Boosters.SlowDownEnemies
{
    public class SlowDownEnemyButton : BoosterButton
    {
        [SerializeField] private SlowDownEnemies _slowDownEnemies;

        private IAudioService _audioService;

        [Inject]
        public void Construct(IAudioService audioService) =>
            _audioService = audioService;

        public override void OffButton() =>
            Button.interactable = false;

        protected override void OnClick()
        {
            _audioService.PlaySfx(SfxType.BoosterSelection);
            OffButton();
            _slowDownEnemies.SlowEnemies();
        }
    }
}