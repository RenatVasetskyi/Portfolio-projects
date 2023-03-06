using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{  
    void Start()
    {
        AudioManager.Instance.PlayMusic(MusicType.MainMenu);
    }
}
