using Assets.Scripts.Boosters;

namespace Assets.Scripts.Architecture.Services.Factories.UI
{
    public interface ILevelUIFactory
    {
        BoosterHolder BoosterHolder { get; }
        void CreateLevelUI();
    }
}