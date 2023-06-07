using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    [CreateAssetMenu(fileName = "Music Holder", menuName = "Create Music Holder/Holder")]
    public class MusicHolder : ScriptableObject
    {
        public List<MusicData> Musics;
    }
}