using UnityEngine;

public class BoatSfxPlayer : MonoBehaviour
{
    private void Awake()
    {
        EventSystem.OnGameStarted.AddListener(PlayEngineSound);
        EventSystem.OnGameOver.AddListener(StopEngineSound);
    }

    private void PlayEngineSound()
    {
        AudioManager.Instance.PlayBoatSfx(BoatSfxType.Engine);
    }

    private void StopEngineSound()
    {
        AudioManager.Instance.StopBoatSfx();
    }
}
