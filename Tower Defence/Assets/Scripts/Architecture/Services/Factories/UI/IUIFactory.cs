using Assets.Scripts.Boosters;
using Assets.Scripts.Tower.Selection;

namespace Assets.Scripts.Architecture.Services.Factories.UI
{
    public interface IUIFactory
    {
        public TowerSelection TowerSelection { get; }
        public BoosterHolder BoosterHolder { get; }
        void CreateMainMenu();
        void CreateLevelSelectionWindow();
        void CreateLevelUI();
        void CreateGameOverWindow();
    }
}