using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    [CreateAssetMenu(fileName = "ButtonsData", menuName = "CreateButtonsData/Data")]
    public class UIButtons : ScriptableObject
    {
        public List<ButtonConfig> ButtonConfigs;
    }
}