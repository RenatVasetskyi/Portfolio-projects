using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    [CreateAssetMenu(fileName = "WindowsData", menuName = "CreateWindowsData/Data")]
    public class UIWindows : ScriptableObject
    {
        public List<WindowConfig> WindowConfigs;
    }
}