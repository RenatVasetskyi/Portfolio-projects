using Assets.Scripts.Data;

namespace Assets.Scripts.Architecture.Services
{
    public interface IStaticDataService
    {
        void Load();
        WindowConfig ForWindow(WindowId id);
        ButtonConfig ForButton(LevelId id);
    }
}