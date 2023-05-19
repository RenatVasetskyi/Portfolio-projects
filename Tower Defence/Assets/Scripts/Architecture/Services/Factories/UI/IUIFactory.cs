using Assets.Scripts.Boosters;
using Assets.Scripts.Data.Windows;
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
        GameObject MeteorCrosshair { get; }
        LevelSelectionWindow LevelSelectionWindow { get; }
        void CreateMainMenu();
        void CreateLevelSelectionWindow();
        void CreateLevelUI();
        void CreateBaseWindow<T>(string path) where T : MonoBehaviour;
        UpgradeTowerWindowView CreateUpgradeTowerWindow(Transform parent);
        void CreateMeteorCrosshair();
    }
}