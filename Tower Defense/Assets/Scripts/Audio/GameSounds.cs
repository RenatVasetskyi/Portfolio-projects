using UnityEngine;
using MyEvents;

namespace Audio
{
    public class GameSounds : MonoBehaviour
    {
        private void Awake()
        {
            Events.OnTowerShot.AddListener(PlayShotSound);
            Events.OnGameStarted.AddListener(PlayGameStartedSound);
            Events.OnNotEnoughMoney.AddListener(PlayNotEnoughMoneySound);
            Events.OnGotCoins.AddListener(PlayGetCoinsSound);
            Events.OnGameOver.AddListener(PlayGameOverSound);
        }

        void Start()
        {
            AudioManager.Instance.PlayMusic(MusicType.Game);
        }     

        private void PlayShotSound()
        {
            AudioManager.Instance.PlaySfx(SfxType.CannonTowerShot);
        }

        private void PlayGameStartedSound()
        {
            AudioManager.Instance.PlaySfx(SfxType.GameStart);
        }     

        private void PlayNotEnoughMoneySound()
        {
            AudioManager.Instance.PlaySfx(SfxType.NotEnoughMoney);
        }

        private void PlayGetCoinsSound()
        {
            AudioManager.Instance.PlaySfx(SfxType.GetCoins);
        }

        private void PlayGameOverSound()
        {
            AudioManager.Instance.PlaySfx(SfxType.GameOver);
        }
    }
}
