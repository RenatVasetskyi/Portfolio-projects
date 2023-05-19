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
        GameObject MeteorCrosshair { get; }
        void CreateMainMenu();
        void CreateLevelSelectionWindow();
        void CreateLevelUI();
        void CreateBaseWindow<T>(string path) where T : MonoBehaviour;
        void CreateMeteorCrosshair();
        UpgradeTowerWindowView CreateUpgradeTowerWindow(Transform parent);
    }
}