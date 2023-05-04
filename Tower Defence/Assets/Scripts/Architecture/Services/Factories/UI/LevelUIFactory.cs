using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Levels;
using Assets.Scripts.Tower.Selection;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Services.Factories.UI
{
    public class LevelUIFactory : ILevelUIFactory
    {
        private readonly DiContainer _container;
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingProvider;
        private readonly IAssetProvider _assetProvider;
        private readonly TowerSelection _towerSelection;

        public LevelUIFactory(DiContainer container, ICurrentLevelSettingsProvider currentLevelSettingProvider, IAssetProvider assetProvider, TowerSelection towerSelection)
        {
            _container = container;
            _currentLevelSettingProvider = currentLevelSettingProvider;
            _assetProvider = assetProvider;
            _towerSelection = towerSelection;
        }

        public void CreateLevelUI()
        {
            LevelSettings currentLevel = GetCurrentLevel();
            Transform parent = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRootCanvas));
            
            CreateButton(currentLevel.CoinsCounter, parent);
            CreateButton(currentLevel.StartWavesButton, parent);
            CreateButton(currentLevel.WaveCounter, parent);
            CreateButton(currentLevel.PlayersHp, parent);

            CreateTowerSelectionButtons(_towerSelection.transform);
        }

        private void CreateTowerSelectionButtons(Transform parent)
        {
            foreach (TowerSelectionButton button in GetCurrentLevel().TowerSelectionButtons.Buttons)
            {
                TowerSelectionButtonHolder spawnedButton = _container.InstantiatePrefabForComponent<TowerSelectionButtonHolder>(button.ButtonPrefab, parent);
                spawnedButton.Tower = button.Tower;
            }
        }

        private void CreateButton(GameObject button, Transform parent)
        {
            if (button != null)
                _container.InstantiatePrefab(button, parent);
        }

        private LevelSettings GetCurrentLevel() =>
            _currentLevelSettingProvider.GetCurrentLevelSettings();

        private Transform CreateParent(Transform parent) =>
            Object.Instantiate(parent);
    }
}