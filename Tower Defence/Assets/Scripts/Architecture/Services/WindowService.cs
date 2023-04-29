using Assets.Scripts.Architecture.Services.Factories;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data.Windows;

namespace Assets.Scripts.Architecture.Services
{
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _uiFactory;

        public WindowService(IUIFactory uiFactory) =>
            _uiFactory = uiFactory;

        public void Open(WindowId windowId)
        {
            switch (windowId)
            {
                case WindowId.Known:
                    break;
                case WindowId.LevelSelection:
                    _uiFactory.CreateLevelSelectionWindow();
                    break;
            }
        }
    }
}