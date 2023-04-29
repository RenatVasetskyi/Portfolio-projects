using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Levels;
using Assets.Scripts.UI.OnLevel.Coins;
using Assets.Scripts.UI.OnLevel.StartWave;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Factories
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
            Transform parent = CreateUIRootCanvas();

            CreateButtonForComponent<ShowCoinsCount>(currentLevel.CoinsCounter, parent);
            CreateButtonForComponent<StartWaveButton>(currentLevel.StartWavesButton, parent);
            CreateButton(currentLevel.WaveCounter, parent);
            CreateButton(currentLevel.PlayersHp, parent);
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

        private Transform CreateUIRootCanvas() =>
            Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.UIRootCanvas));
    }
}