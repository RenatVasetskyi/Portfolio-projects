using UnityEngine;

[System.Serializable]
public class BoatSfxData
{
    [SerializeField] private BoatSfxType _boatSfxType;
    [SerializeField] private AudioClip _clip;

    public BoatSfxType BoatSfxType => _boatSfxType;
    public AudioClip Clip => _clip;
}
