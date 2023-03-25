using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _musicSource;

    [SerializeField] private List<MusicData> _musicDataList = new List<MusicData>();
    [SerializeField] private List<SfxData> _sfxDataList = new List<SfxData>();

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
        var result = _musicDataList.Find(data => data.Type == musicType);
        return result;
    }

    private SfxData GetSfxData(SfxType sfxType)
    {
        var result = _sfxDataList.Find(data => data.Type == sfxType);
        return result;
    }
}
