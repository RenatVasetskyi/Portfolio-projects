using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveSettings : MonoBehaviour
{ 
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _sfxToggle;

    private string _savePath = "Data/Settings.json";
    private string _fileName = "Volume.json";
    
    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _savePath = Path.Combine(Application.persistentDataPath, _fileName);
#else
        _savePath = Path.Combine(Application.dataPath, _fileName);
#endif

        Load();
    }

    private void OnApplicationPause(bool pause)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Save();
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void Save()
    {
        SettingsPanelStruct settingsPanel = new SettingsPanelStruct()
        {
            MusicVolume = _musicSlider.value,
            SfxVolume = _sfxSlider.value,
            MusicToggle = _musicToggle.isOn,
            SfxToggle = _sfxToggle.isOn
        };

        try
        {
            string json = JsonUtility.ToJson(settingsPanel, true);
            File.WriteAllText(_savePath, json);
        }
        catch (System.Exception)
        {
            Debug.Log("Save interrupted");
        }
    }

    private void Load()
    {
        if (!File.Exists(_savePath))
        {          
            return;
        }

        try
        {
            string json = File.ReadAllText(_savePath);

            SettingsPanelStruct settingsPanel = JsonUtility.FromJson<SettingsPanelStruct>(json);
            this._musicSlider.value = settingsPanel.MusicVolume;
            this._sfxSlider.value = settingsPanel.SfxVolume;
            this._musicToggle.isOn = settingsPanel.MusicToggle;
            this._sfxToggle.isOn = settingsPanel.SfxToggle;
        }
        catch (System.Exception)
        {
            Debug.Log("Load interrupted");
        }          
    }
}
