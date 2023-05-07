using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    [CreateAssetMenu(fileName = "Sound Effects Holder", menuName = "Create Sound Effects Holder/Holder")]
    public class SfxHolder : ScriptableObject
    {
        public List<SfxData> SoundEffects;
    }
}