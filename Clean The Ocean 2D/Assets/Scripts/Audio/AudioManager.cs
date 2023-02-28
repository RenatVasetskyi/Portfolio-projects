using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private List<SfxData> _sfxDataList = new List<SfxData>();
    [SerializeField] private List<MusicData> _musicDataList = new List<MusicData>();
    [SerializeField] private List<BoatSfxData> _boatSfxDataList = new List<BoatSfxData>();

    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _boatSource;

    public void PlayMusic(MusicType musicType)
    {     
        var musicData = GetMusicData(musicType);
        _musicSource.clip = musicData.Clip;
        _musicSource.Play();
    }

    public void PlaySfx(SfxType sfxType) 
    {      
        var sfxData = GetSfxData(sfxType);
        _sfxSource.PlayOneShot(sfxData.Clip);
    }

    public void PlayBoatSfx(BoatSfxType boatSfxType)
    {                
        var boatsfxData = GetBoatSfxData(boatSfxType);
        _boatSource.PlayOneShot(boatsfxData.Clip);       
    }

    public void StopBoatSfx()
    {     
        _boatSource.Stop();
    }

    public void StopMusic()
    {
        _musicSource.Stop();
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

    private MusicData GetMusicData(MusicType musicType)
    {
        var result = _musicDataList.Find(data => data.MusicType == musicType);
        return result;
    }

    private SfxData GetSfxData(SfxType sfxType)
    {
        var result = _sfxDataList.Find(data => data.SfxType == sfxType);
        return result;
    }

    private BoatSfxData GetBoatSfxData(BoatSfxType boatSfxType)
    {
        var result = _boatSfxDataList.Find(data => data.BoatSfxType == boatSfxType);
        return result;
    }
}
