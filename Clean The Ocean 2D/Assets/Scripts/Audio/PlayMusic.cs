using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    private void Awake()
    {
        EventSystem.OnGameStarted.AddListener(PlayGameMusic);
        EventSystem.OnGameOver.AddListener(StopGameMusic);
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
