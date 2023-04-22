using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<WindowId, WindowConfig> _windows;

        public StaticDataService() => Load();

        public void Load()
        {
            _windows = Resources
                .Load<UIWindows>(AssetPath.UIWindows)
                .WindowConfigs
                .ToDictionary(x => x.Id, x => x);
        }

        public WindowConfig ForWindow(WindowId id) =>
            _windows.TryGetValue(id, out WindowConfig config)
                ? config
                : null;
    }
}