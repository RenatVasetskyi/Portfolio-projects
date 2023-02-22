using UnityEngine;

[System.Serializable]
public class MusicData
{
    [SerializeField] private MusicType _musicType;
    [SerializeField] private AudioClip _clip;

    public MusicType MusicType => _musicType;
    public AudioClip Clip => _clip;
}
