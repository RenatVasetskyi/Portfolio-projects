namespace Assets.Scripts.Architecture.Services
{
    public interface IStaticDataService
    {
        void Load();
        WindowConfig ForWindow(WindowId id);
    }
}