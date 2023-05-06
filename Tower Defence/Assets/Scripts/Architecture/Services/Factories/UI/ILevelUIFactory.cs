using Assets.Scripts.Boosters;
using Assets.Scripts.Tower.Selection;

namespace Assets.Scripts.Architecture.Services.Factories.UI
{
    public interface ILevelUIFactory
    {
        TowerSelection TowerSelection { get; }
        BoosterHolder BoosterHolder { get; }
        void CreateLevelUI();
    }
}