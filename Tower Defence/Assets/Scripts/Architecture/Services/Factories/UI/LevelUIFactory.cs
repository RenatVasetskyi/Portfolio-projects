using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Levels;
using Assets.Scripts.Tower.TowerSelection;
using Assets.Scripts.UI.OnLevel.Coins;
using Assets.Scripts.UI.OnLevel.StartWave;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Services.Factories
{
    public class LevelUIFactory : ILevelUIFactory
    {
        private readonly DiContainer _container;
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingProvider;
        private readonly IAssetProvider _assetProvider;

        public LevelUIFactory(DiContainer container, ICurrentLevelSettingsProvider currentLevelSettingProvider, IAssetProvider assetProvider)
        {
            _container = container;
            _currentLevelSettingProvider = currentLevelSettingProvider;
            _assetProvider = assetProvider;
        }

        public void CreateLevelUI()
        {
            LevelSettings currentLevel = GetCurrentLevel();
            Transform parent = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRootCanvas));
            
            CreateButtonForComponent<ShowCoinsCount>(currentLevel.CoinsCounter, parent);
            CreateButtonForComponent<StartWaveButton>(currentLevel.StartWavesButton, parent);
            CreateButton(currentLevel.WaveCounter, parent);
            CreateButton(currentLevel.PlayersHp, parent);

            GameObject towerSelectionButtonChanger = CreateTowerSelectionButtonChanger(parent);

            CreateTowerSelectionButtons(towerSelectionButtonChanger.transform);
        }

        private void CreateTowerSelectionButtons(Transform parent)
        {
            foreach (var button in GetCurrentLevel().TowerSelectionButtons.Buttons)
                _container.InstantiatePrefab(button.ButtonPrefab, parent);
        }

        private void CreateButtonForComponent<T>(GameObject button, Transform parent)
        {
            if (button != null)
                _container.InstantiatePrefabForComponent<T>(button, parent);
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

        private GameObject CreateTowerSelectionButtonChanger(Transform parent) =>
            Object.Instantiate(_assetProvider.Initialize<GameObject>(AssetPath.LayoutGroup), parent);
    }
}