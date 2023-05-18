using Assets.Scripts.Boosters;
using Assets.Scripts.Tower.Characteristics;
using Assets.Scripts.Tower.Selection;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services.Factories.UI
{
    public interface IUIFactory
    {
        TowerSelection TowerSelection { get; }
        BoosterHolder BoosterHolder { get; }
        Transform LevelUIRoot { get; }
        void CreateMainMenu();
        void CreateLevelSelectionWindow();
        void CreateLevelUI();
        void CreateWindow<T>(string path) where T : MonoBehaviour;
        UpgradeTowerWindowView CreateUpgradeTowerWindow(Transform parent);
    }
}