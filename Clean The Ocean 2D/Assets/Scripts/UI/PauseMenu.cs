using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{ 
    [SerializeField] private GameObject _pauseWindow;

    [SerializeField] private Button _pause;
    [SerializeField] private Button _resume;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _backToMenu;

    private float _scaleDuration = 0.2f;
    
    private void Start()
    {
        _pause.onClick.AddListener(OnPauseButtonClickHandler);
        _resume.onClick.AddListener(OnResumeButtonClickHandler);
        _backToMenu.onClick.AddListener(OnBackToMenuButtonClickHandler);
        _settings.onClick.AddListener(OnSettingsButtonClickHandler);
    }

    private void OnPauseButtonClickHandler()
    {
        OpenPauseWindow();
    }

    private void OnResumeButtonClickHandler()
    {
        ClosePauseWindow();
    }

    private void OnSettingsButtonClickHandler()
    {
        SettingsPanel.Instance.OpenSettingsPanel();
    }

    private void OnBackToMenuButtonClickHandler()
    {
        MainMenu.Instance.OpenMenuPanel();
        SceneManager.LoadScene(Scenes.MainMenu.ToString());
    }

    private void OpenPauseWindow()
    {
        LeanTween.scale(_pauseWindow, Vector3.one, _scaleDuration);
    }

    private void ClosePauseWindow()
    {
        LeanTween.scale(_pauseWindow, Vector3.zero, _scaleDuration);
    }
}
