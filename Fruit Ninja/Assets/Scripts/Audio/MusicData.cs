using UnityEngine;

namespace Audio
{
    [System.Serializable]
    public class MusicData
    {
        [SerializeField] private MusicType _type;
        [SerializeField] private AudioClip _clip;

        public MusicType Type => _type;
        public AudioClip Clip => _clip;
    }
}
