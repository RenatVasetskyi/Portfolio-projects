using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Boosters;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Levels;
using Assets.Scripts.GameOver;
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

        public TowerSelection TowerSelection { get; private set; }
        public BoosterHolder BoosterHolder { get; private set; }

        public LevelUIFactory(DiContainer container, ICurrentLevelSettingsProvider currentLevelSettingProvider, IAssetProvider assetProvider)
        {
            _container = container;
            _currentLevelSettingProvider = currentLevelSettingProvider;
            _assetProvider = assetProvider;
        }

        public void CreateLevelUI()
        {
            Transform parent = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRootCanvas));

            CreateMainUIElements(parent);

            CreateTowerSelection(parent);
            CreateTowerSelectionButtons(TowerSelection);

            CreateBoosterHolder(parent);
            CreateBoosterButtons();
        }

        public void CreateGameOverWindow()
        {
            Vector3 startPosition = new Vector3(0, Screen.height, 0);

            GameObject parent = Object.Instantiate(_assetProvider
                    .Initialize<GameObject>(AssetPath.GameOverWindowCanvas));

            GameOverWindow window = _container
                .InstantiatePrefabForComponent<GameOverWindow>(_assetProvider
                    .Initialize<GameOverWindow>(AssetPath.GameOverWindow), parent.transform);

            window.transform.localPosition = startPosition;
        }

        private void CreateTowerSelectionButtons(TowerSelection towerSelection)
        {
            foreach (TowerSelectionButton button in GetCurrentLevel().TowerSelectionButtons.Buttons)
            {
                TowerSelectionButtonHolder spawnedButton = _container
                    .InstantiatePrefabForComponent<TowerSelectionButtonHolder>(button.ButtonPrefab, towerSelection.transform);

                spawnedButton.Tower = button.Tower;
                towerSelection.Buttons.Add(spawnedButton);
            }
        }

        private void CreateBoosterButtons()
        {
            foreach (BoosterButton boosterButton in GetCurrentLevel().Boosters)
            {
                BoosterButton spawnedBoosterButton = _container.
                    InstantiatePrefabForComponent<BoosterButton>(boosterButton, BoosterHolder.transform);

                BoosterHolder.BoosterButtons.Add(spawnedBoosterButton);
            }
        }

        private void CreateMainUIElements(Transform parent)
        {
            foreach (GameObject element in GetCurrentLevel().MainLevelUIElements)
                _container.InstantiatePrefab(element, parent);
        }

        private void CreateBoosterHolder(Transform parent)
        {
            BoosterHolder = _container
                .InstantiatePrefabForComponent<BoosterHolder>(_assetProvider
                    .Initialize<BoosterHolder>(AssetPath.BoosterHolder), parent);
        }

        private void CreateTowerSelection(Transform parent)
        {
            TowerSelection = _container
                .InstantiatePrefabForComponent<TowerSelection>(_assetProvider
                    .Initialize<TowerSelection>(AssetPath.TowerSelection), parent);
        }

        private LevelSettings GetCurrentLevel() =>
            _currentLevelSettingProvider.GetCurrentLevelSettings();

        private Transform CreateParent(Transform parent) =>
            Object.Instantiate(parent);
    }
}