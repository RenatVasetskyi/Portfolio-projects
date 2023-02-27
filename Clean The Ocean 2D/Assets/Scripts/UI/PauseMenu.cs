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
        AudioManager.Instance.PlaySfx(SfxType.Click);
        OpenPauseWindow();
    }

    private void OnResumeButtonClickHandler()
    {
        AudioManager.Instance.PlaySfx(SfxType.Click);
        ClosePauseWindow();
    }

    private void OnSettingsButtonClickHandler()
    {
        AudioManager.Instance.PlaySfx(SfxType.Click);
        SettingsPanel.Instance.OpenSettingsPanel();
    }

    private void OnBackToMenuButtonClickHandler()
    {
        AudioManager.Instance.StopBoatSfx();
        MainMenu.Instance.OpenMenuPanel();     
        SceneManager.LoadScene(Scenes.MainMenu.ToString());
    }

    private void OpenPauseWindow()
    {
        AudioManager.Instance.PlaySfx(SfxType.Click);
        LeanTween.scale(_pauseWindow, Vector3.one, _scaleDuration);
    }

    private void ClosePauseWindow()
    {
        AudioManager.Instance.PlaySfx(SfxType.Click);
        LeanTween.scale(_pauseWindow, Vector3.zero, _scaleDuration);
    }
}
