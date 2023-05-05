using Assets.Scripts.Boosters;

namespace Assets.Scripts.Architecture.Services.Factories.UI
{
    public interface ILevelUIFactory
    {
        void CreateLevelUI();
        BoosterHolder BoosterHolder { get; }
    }
}