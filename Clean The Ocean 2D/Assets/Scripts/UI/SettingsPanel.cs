using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    public static SettingsPanel Instance;

    [SerializeField] private GameObject _settingsPanel;

    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _sfxVolume;

    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _sfxToggle;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _boatSfxSource;

    [SerializeField] private Button _closePanelButton;

    private float _scaleDuration = 0.2f;

    public void CloseSettingsPanel()
    {
        LeanTween.scale(_settingsPanel, Vector3.zero, _scaleDuration);
        AudioManager.Instance.PlaySfx(SfxType.Click);
    }

    public void OpenSettingsPanel()
    {
        LeanTween.scale(_settingsPanel, Vector3.one, _scaleDuration);
        AudioManager.Instance.PlaySfx(SfxType.Click);
    }

    private void Update()
    {       
        MusicVolume();
        SfxVolume();
        BoatSfxVolume();
    }

    private void Start()
    {
        _closePanelButton.onClick.AddListener(OnClosePanelClickHandler);
    }

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
    }

    private void MusicVolume()
    {
        if (_musicToggle.isOn == true)
        {
            _musicSource.volume = _musicVolume.value;
        }
        else
        {
            _musicSource.volume = 0;
        }
    }  
    
    private void SfxVolume()
    {
        if (_sfxToggle.isOn == true)
        {
            _sfxSource.volume = _sfxVolume.value;
        }
        else
        {
            _sfxSource.volume = 0;          
        }      
    }

    private void BoatSfxVolume()
    {
        if (_sfxToggle.isOn == true)
        {
            _boatSfxSource.volume = _sfxVolume.value;
        }
        else
        {
            _boatSfxSource.volume = 0;
        }      
    }

    private void OnClosePanelClickHandler()
    {
        CloseSettingsPanel();
        AudioManager.Instance.PlaySfx(SfxType.Click);
    }   
}
