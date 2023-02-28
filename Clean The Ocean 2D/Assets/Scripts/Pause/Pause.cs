using UnityEngine;

public class Pause : MonoBehaviour
{
    public void PauseGame()
    {
        AudioManager.Instance.StopBoatSfx();
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        AudioManager.Instance.PlayBoatSfx(BoatSfxType.Engine);
        Time.timeScale = 1;
    }
}
