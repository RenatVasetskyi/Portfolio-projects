using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _exit;

    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private Button _closePanelButton;

    private float _scaleDuration = 0.2f; 
       
    private void Awake()
    {
        _play.onClick.AddListener(OnPlayClickHandler);
        _settings.onClick.AddListener(OnSettingsClickHandler);
        _exit.onClick.AddListener(OnExitClickHandler);
        _closePanelButton.onClick.AddListener(OnClosePanelClickHandler);

        AudioManager.Instance.PlayMusic(MusicType.Menu);       
    }

    private void OnPlayClickHandler()
    {
        AudioManager.Instance.PlaySfx(SfxType.Click);
        AudioManager.Instance.PlayMusic(MusicType.Game);
        AudioManager.Instance.PlayBoatSfx(BoatSfxType.Engine);
        
        SceneManager.LoadScene(Scenes.Game.ToString());     
    }

    private void OnSettingsClickHandler()
    {
        LeanTween.scale(_settingsPanel, Vector3.one, _scaleDuration);
        AudioManager.Instance.PlaySfx(SfxType.Click);             
    }
    
    private void OnExitClickHandler()
    {     
        AudioManager.Instance.PlaySfx(SfxType.Click);
        Application.Quit();      
    }

    private void OnClosePanelClickHandler()
    {
        LeanTween.scale(_settingsPanel, Vector3.zero, _scaleDuration);
        AudioManager.Instance.PlaySfx(SfxType.Click);       
    }
}
