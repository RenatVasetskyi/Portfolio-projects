using Assets.Scripts.Architecture.Services;

namespace Assets.Scripts.UI
{
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _uiFactory;

        public WindowService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Open(WindowId windowId)
        {
            switch (windowId)
            {
                case WindowId.Known:
                    break;
                case WindowId.LevelSelection:
                    _uiFactory.CreateWindow();
                    break;
            }
        }
    }
}