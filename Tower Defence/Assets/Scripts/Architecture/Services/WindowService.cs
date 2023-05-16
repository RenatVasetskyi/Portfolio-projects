using Assets.Scripts.Architecture.Services.Factories.UI;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Windows;
using Assets.Scripts.UI;

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
                case WindowId.GameOver:
                    _uiFactory.CreateWindow<MovableWindow>(AssetPath.GameOverWindow);
                    break;
                case WindowId.Victory:
                    _uiFactory.CreateWindow<MovableWindow>(AssetPath.VictoryWindow);
                    break;
            }
        }
    }
}