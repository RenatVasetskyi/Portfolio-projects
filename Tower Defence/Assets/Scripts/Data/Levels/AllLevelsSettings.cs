using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data.Levels
{
    [CreateAssetMenu(fileName = "LevelsHolder", menuName = "CreateLevelsHolder")]
    public class AllLevelsSettings : ScriptableObject
    {
        public List<LevelSettings> Levels;
    }
}