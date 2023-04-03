using UnityEngine;
using Events;

namespace Audio
{
    public class GameSounds : MonoBehaviour
    {
        private void Awake()
        {          
            EventManager.TowerShot.AddListener(PlayShotSound);
            EventManager.GameStarted.AddListener(PlayGameStartedSound);          
            EventManager.NotEnoughMoney.AddListener(PlayNotEnoughMoneySound);
            EventManager.GetCoins.AddListener(PlayGetCoinsSound);
            EventManager.GameOver.AddListener(PlayGameOverSound);
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
