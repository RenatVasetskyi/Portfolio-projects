using Assets.Scripts.Data.Windows;

namespace Assets.Scripts.Architecture.Services.Interfaces
{
    public interface IStaticDataService
    {
        void Load();
        WindowConfig ForWindow(WindowId id);
    }
}