using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _pauseWindow;

    [SerializeField] private Button _continue;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _backToMenu;

    private float _scaleDuration = 0.2f;
    
    private void Start()
    {       
        _pauseButton.onClick.AddListener(OnPauseButtonClickHandler);
        _continue.onClick.AddListener(OnContinueButtonClickHandler);
        _backToMenu.onClick.AddListener(OnBackToMenuButtonClickHandler);
        _settings.onClick.AddListener(OnSettingsButtonClickHandler);
    }
  
    private void OnPauseButtonClickHandler()
    {
        OpenPauseWindow();       
    }

    private void OnContinueButtonClickHandler()
    {
        ClosePauseWindow();
    }

    private void OnSettingsButtonClickHandler()
    {
        SettingsPanelCanvas.Instance.OpenSettingsPanel();
    }

    private void OnBackToMenuButtonClickHandler()
    {
        MainMenuCanvas.Instance.OpenMenuPanel();
        SceneManager.LoadScene(Scenes.MainMenu.ToString());
    }

    private void OpenPauseWindow()
    {
        LeanTween.scale(_pauseWindow, Vector3.one, _scaleDuration * Time.unscaledDeltaTime);
    }

    private void ClosePauseWindow()
    {
        LeanTween.scale(_pauseWindow, Vector3.zero, _scaleDuration);
    }
}
