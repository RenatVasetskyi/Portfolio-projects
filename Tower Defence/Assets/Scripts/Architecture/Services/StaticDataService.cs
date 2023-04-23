using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<WindowId, WindowConfig> _windows;
        private Dictionary<LevelId, ButtonConfig> _buttons;

        public StaticDataService() => Load();

        public void Load()
        {
            _windows = Resources
                .Load<UIWindows>(AssetPath.UIWindows)
                .WindowConfigs
                .ToDictionary(x => x.Id, x => x);

            _buttons = Resources
                .Load<UIButtons>(AssetPath.UIButtons)
                .ButtonConfigs
                .ToDictionary(x => x.Id, x => x);
        }

        public WindowConfig ForWindow(WindowId id) =>
            _windows.TryGetValue(id, out WindowConfig config)
                ? config
                : null;

        public ButtonConfig ForButton(LevelId id) =>
            _buttons.TryGetValue(id, out ButtonConfig config)
                ? config
                : null;
    }
}