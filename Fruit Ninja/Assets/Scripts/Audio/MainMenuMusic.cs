using UnityEngine;

namespace Audio
{
    public class MainMenuMusic : MonoBehaviour
    {
        void Start()
        {
            AudioManager.Instance.PlayMusic(MusicType.MainMenu);
        }
    }
}
