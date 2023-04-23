namespace Assets.Scripts.Architecture.Factories
{
    public interface IUIFactory
    {
        void CreateMainMenu();
        void CreateMainWindow();
        void CreateLevelSelectionWindow();
        void InitTransferButtonMarkers();
        void CreateLevelTransferButton();
    }
}