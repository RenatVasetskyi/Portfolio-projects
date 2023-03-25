using UnityEngine;

public class PlayGameMusic : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlayMusic(MusicType.Game);
    }
}
