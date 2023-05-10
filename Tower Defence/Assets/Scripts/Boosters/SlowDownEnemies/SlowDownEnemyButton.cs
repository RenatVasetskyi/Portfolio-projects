using Assets.Scripts.Audio;
using UnityEngine;

namespace Assets.Scripts.Boosters.SlowDownEnemies
{
    public class SlowDownEnemyButton : BoosterButton
    { 
        [SerializeField] private SlowDownEnemies _slowDownEnemies;

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