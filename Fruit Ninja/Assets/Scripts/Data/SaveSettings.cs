using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class SaveSettings : MonoBehaviour
    {
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
            if (Application.platform == RuntimePlatform.Android)
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
            SettingsStruct settingsScruct = new SettingsStruct()
            {             
                MusicToggle = _musicToggle.isOn,
                SfxToggle = _sfxToggle.isOn
            };

            try
            {
                string json = JsonUtility.ToJson(settingsScruct, true);
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

                SettingsStruct settingsStruct = JsonUtility.FromJson<SettingsStruct>(json);              
                this._musicToggle.isOn = settingsStruct.MusicToggle;
                this._sfxToggle.isOn = settingsStruct.SfxToggle;
            }
            catch (System.Exception)
            {
                Debug.Log("Load interrupted");
            }
        }
    }
}
