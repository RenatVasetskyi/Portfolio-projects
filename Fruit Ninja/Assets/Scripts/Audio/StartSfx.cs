using UnityEngine;

public class StartSfx : MonoBehaviour
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
