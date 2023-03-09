using UnityEngine;

namespace Audio
{
    public class GameMusic : MonoBehaviour
    {
        private void Awake()
        {
            Events.OnGameStarted.AddListener(PlayGameMusic);
            Events.OnBombExploded.AddListener(StopGameMusic);
        }

        private void PlayGameMusic()
        {
            AudioManager.Instance.PlayMusic(MusicType.Game);
        }

        private void StopGameMusic()
        {
            AudioManager.Instance.StopMusic();
        }
    }
}
