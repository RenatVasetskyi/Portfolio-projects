using UnityEngine;

[System.Serializable]
public class SfxData
{
    [SerializeField] private SfxType _type;
    [SerializeField] private AudioClip _clip;

    public SfxType Type => _type;
    public AudioClip Clip => _clip;
}
   
