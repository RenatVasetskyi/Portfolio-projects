using UnityEngine;

public class Pause : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
    }

    private void Awake()
    {
        Events.OnGamePaused.AddListener(PauseGame);
        Events.OnGameUnPaused.AddListener(UnpauseGame);
    }
}
