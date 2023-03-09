using Audio;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class Settings : MonoBehaviour
    {
        public static Settings Instance;

        [SerializeField] private Transform _settingsPanel;
        [SerializeField] private Button _settingsButton;

        [SerializeField] private Toggle _musicToggle;
        [SerializeField] private Toggle _sfxToggle;

        [SerializeField] private Button _closePanelButton;

        [SerializeField] private CanvasGroup _background;
        [SerializeField] private float _duration = 0.5f;

        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            _settingsButton.onClick.AddListener(OnSettingsButtonClickHandler);
            _closePanelButton.onClick.AddListener(OnClosePanelButtonClickHandler);

            Events.OnBombExploded.AddListener(OffSettingsButton);
            Events.OnGameStarted.AddListener(OnSettingsButton);
            Events.OnMainMenuOpened.AddListener(OnSettingsButton);
        }

        private void Update()
        {
            if (_musicToggle.isOn)
                _musicSource.volume = 1f;
            else
                _musicSource.volume = 0f;

            if (_sfxToggle.isOn)
                _sfxSource.volume = 1f;
            else
                _sfxSource.volume = 0f;
        }

        private void OnSettingsButtonClickHandler()
        {
            Events.SendOnGamePaused();
            AudioManager.Instance.PlaySfx(SfxType.Click);
            OpenPanel();
        }

        private void OnClosePanelButtonClickHandler()
        {
            Events.SendOnGameUnPaused();
            AudioManager.Instance.PlaySfx(SfxType.Click);
            ClosePanel();
        }

        private void OpenPanel()
        {
            _background.alpha = 0f;
            _background.LeanAlpha(0.7f, _duration).setIgnoreTimeScale(true);

            _settingsPanel.localPosition = new Vector2(0, -Screen.height);
            _settingsPanel.LeanMoveLocalY(0f, _duration).setEaseOutExpo().setIgnoreTimeScale(true).delay = 0.1f;

            AudioManager.Instance.PlaySfx(SfxType.Window);
        }

        private void ClosePanel()
        {
            _background.LeanAlpha(0, _duration).setIgnoreTimeScale(true);
            _settingsPanel.LeanMoveLocalY(Screen.height, _duration).setEaseInExpo().setIgnoreTimeScale(true);

            AudioManager.Instance.PlaySfx(SfxType.Window);
        }

        private void OffSettingsButton()
        {
            _settingsButton.enabled = false;
        }

        private void OnSettingsButton()
        {
            _settingsButton.enabled = true;
        }
    }
}
