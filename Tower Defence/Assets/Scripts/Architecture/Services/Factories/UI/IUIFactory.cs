using Assets.Scripts.Boosters;
using Assets.Scripts.Tower.Characteristics;
using Assets.Scripts.Tower.Selection;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services.Factories.UI
{
    public interface IUIFactory
    {
        public TowerSelection TowerSelection { get; }
        public BoosterHolder BoosterHolder { get; }
        Transform LevelUIRoot { get; }
        void CreateMainMenu();
        void CreateLevelSelectionWindow();
        void CreateLevelUI();
        void CreateGameOverWindow();
        UpgradeTowerWindowView CreateUpgradeTowerWindow(Transform parent, TowerCharacteristics towerCharacteristics);
    }
}