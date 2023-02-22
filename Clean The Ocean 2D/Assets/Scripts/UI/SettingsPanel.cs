using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{   
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _sfxVolume;

    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _sfxToggle;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _boatSfxSource;   

    private void Update()
    {       
        MusicVolume();
        SfxVolume();
        BoatSfxVolume();
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
        _boatSfxSource.volume = _sfxVolume.value;
    } 
}
