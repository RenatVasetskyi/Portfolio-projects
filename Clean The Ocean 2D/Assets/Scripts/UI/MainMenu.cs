using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;

    [SerializeField] private GameObject _menuPanel;

    [SerializeField] private Button _play;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _exit; 
       
    public void HideMainMenu()
    {
        _menuPanel.SetActive(false);
    }

    public void OpenMenuPanel()
    {
        _menuPanel.SetActive(true);
    }

    private void Awake()
    {
        EventSystem.OnGameStarted.AddListener(HideMainMenu);

        _play.onClick.AddListener(OnPlayClickHandler);
        _settings.onClick.AddListener(OnSettingsClickHandler);
        _exit.onClick.AddListener(OnExitClickHandler);      

        AudioManager.Instance.PlayMusic(MusicType.Menu);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnPlayClickHandler()
    {
        AudioManager.Instance.PlaySfx(SfxType.Click);     
        EventSystem.SendGameStarted();
    }

    private void OnSettingsClickHandler()
    {
        SettingsPanel.Instance.OpenSettingsPanel();     
        AudioManager.Instance.PlaySfx(SfxType.Click);             
    }
    
    private void OnExitClickHandler()
    {     
        AudioManager.Instance.PlaySfx(SfxType.Click);
        Application.Quit();      
    }  
}
