using UnityEngine;

public class GameMusic : MonoBehaviour
{
    private void Awake()
    {
        Events.OnGameStarted.AddListener(PlayGameMusic);
        Events.OnGameOver.AddListener(StopGameMusic);
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
