using UnityEngine;

public class GameStartSfx : MonoBehaviour
{
    private void Awake()
    {
        Events.OnGameStarted.AddListener(PlayStartSfx);
    }

    private void PlayStartSfx()
    {
        AudioManager.Instance.PlaySfx(SfxType.GameStart);
    }
}
