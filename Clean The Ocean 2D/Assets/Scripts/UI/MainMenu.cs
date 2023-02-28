using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;

    [SerializeField] private Button _play;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _exit; 
       
    private void Awake()
    {
        AudioManager.Instance.PlayMusic(MusicType.Menu);

        _play.onClick.AddListener(OnPlayClickHandler);
        _settings.onClick.AddListener(OnSettingsClickHandler);
        _exit.onClick.AddListener(OnExitClickHandler);                
    }

    private void OnPlayClickHandler()
    {
        AudioManager.Instance.PlaySfx(SfxType.Click);     
        EventSystem.SendGameStarted();
    }

    private void OnSettingsClickHandler()
    {
        AudioManager.Instance.PlaySfx(SfxType.Click);
        SettingsPanel.Instance.OpenSettingsPanel();                        
    }
    
    private void OnExitClickHandler()
    {     
        AudioManager.Instance.PlaySfx(SfxType.Click);
        Application.Quit();      
    }  
}
