using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    public interface IUIFactory
    {
        GameObject CreateLevelSelectionWindow();
        void CreateMainMenu();
    }
}