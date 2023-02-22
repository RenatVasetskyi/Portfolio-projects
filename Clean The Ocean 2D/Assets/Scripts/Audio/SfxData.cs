using UnityEngine;

[System.Serializable]
public class SfxData
{
    [SerializeField] private SfxType _sfxType;
    [SerializeField] private AudioClip _clip;

    public SfxType SfxType => _sfxType;
    public AudioClip Clip => _clip;
}
