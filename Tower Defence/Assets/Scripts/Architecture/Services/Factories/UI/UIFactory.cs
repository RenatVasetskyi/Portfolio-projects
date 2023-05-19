using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Boosters;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Levels;
using Assets.Scripts.Data.Windows;
using Assets.Scripts.Tower.Characteristics;
using Assets.Scripts.Tower.Selection;
using Assets.Scripts.UI.MainMenu;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Architecture.Services.Factories.UI
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingProvider;

        private AllLevelsSettings _allLevelsSettings;
        private LevelSettings _currentLevelSettings;

        private LevelSelectionWindow _levelSelectionWindow;

        public TowerSelection TowerSelection { get; private set; }
        public BoosterHolder BoosterHolder { get; private set; }
        public Transform LevelUIRoot { get; private set; }
        public GameObject MeteorCrosshair { get; private set; }
        
        public UIFactory(DiContainer container, IAssetProvider assetProvider, ICurrentLevelSettingsProvider currentLevelSettingProvider)
        {
            _container = container;
            _currentLevelSettingProvider = currentLevelSettingProvider;
            _assetProvider = assetProvider;

            CacheVariables();
        }

        public void CreateMainMenu()
        {
            Transform uiRoot = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRoot));

            MainMenu mainMenu = _assetProvider.Initialize<MainMenu>(AssetPath.MainMenuWindow);
            _container.InstantiatePrefabForComponent<MainMenu>(mainMenu, uiRoot);
        }

        public void CreateLevelSelectionWindow()
        {
            Transform parent = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRootCanvas));

            LevelSelectionWindow window = _container.InstantiatePrefabForComponent<LevelSelectionWindow>(_levelSelectionWindow, parent);

            CreateLevelTransferButtons(window);
        }

        public void CreateLevelUI()
        {
            LevelUIRoot = CreateParent(_assetProvider.Initialize<Transform>(AssetPath.UIRootCanvas));

            CreateMainUIElements(LevelUIRoot);

            CreateTowerSelection(LevelUIRoot);
            CreateTowerSelectionButtons(TowerSelection);

            CreateBoosterHolder(LevelUIRoot);
            CreateBoosterButtons();
        }

        public void CreateBaseWindow<T>(string path) where T : MonoBehaviour
        {
            Vector3 startPosition = new Vector3(0, Screen.height, 0);

            GameObject parent = Object.Instantiate(_assetProvider
                .Initialize<GameObject>(AssetPath.WindowParent));

            T window = _container
                .InstantiatePrefabForComponent<T>(_assetProvider
                    .Initialize<T>(path), parent.transform);

            window.transform.localPosition = startPosition;
        }

        public UpgradeTowerWindowView CreateUpgradeTowerWindow(Transform parent)
        {
            UpgradeTowerWindowView window = _container
                .InstantiatePrefabForComponent<UpgradeTowerWindowView>(_assetProvider
                    .Initialize<UpgradeTowerWindowView>(AssetPath.UpgradeTowerWindow), parent);

            return window;
        }

        public void CreateMeteorCrosshair() =>
            MeteorCrosshair = Object.Instantiate(_assetProvider.Initialize<GameObject>(AssetPath.MeteorCrosshair));

        private void CreateTowerSelectionButtons(TowerSelection towerSelection)
        {
            GetCurrentLevelSettings();

            foreach (TowerSelectionButton button in _currentLevelSettings.TowerSelectionButtons.Buttons)
            {
                TowerSelectionButtonHolder spawnedButton = _container
                    .InstantiatePrefabForComponent<TowerSelectionButtonHolder>(button.ButtonPrefab, towerSelection.transform);

                spawnedButton.Tower = button.Tower;
                towerSelection.Buttons.Add(spawnedButton);
            }
        }

        private void CreateLevelTransferButtons(LevelSelectionWindow window)
        {
            foreach (LevelTransferButtonMarker marker in window.Markers)
            {
                foreach (LevelSettings level in _allLevelsSettings.Levels)
                {
                    if (level.Id == marker.Id)
                        marker.IsOpened = level.IsLevelOpened;
                }

                if (marker.IsOpened == true)
                {
                    LevelTransferButton button = _container.InstantiatePrefabForComponent<LevelTransferButton>(marker.OpenedButton,
                        marker.transform.position, Quaternion.identity, marker.transform);

                    button.LevelId = marker.Id;
                }
                else
                {
                    _container.InstantiatePrefab(marker.ClosedButton,
                        marker.transform.position, Quaternion.identity, marker.transform);
                }
            }
        }

        private void CreateBoosterButtons()
        {
            GetCurrentLevelSettings();

            foreach (BoosterButton boosterButton in _currentLevelSettings.Boosters)
            {
                BoosterButton spawnedBoosterButton = _container.
                    InstantiatePrefabForComponent<BoosterButton>(boosterButton, BoosterHolder.transform);

                BoosterHolder.BoosterButtons.Add(spawnedBoosterButton);
            }
        }

        private void CreateMainUIElements(Transform parent)
        {
            GetCurrentLevelSettings();

            foreach (GameObject element in _currentLevelSettings.MainLevelUIElements)
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

        private Transform CreateParent(Transform parent) =>
            Object.Instantiate(parent);
        
        private void CacheVariables()
        {
            _levelSelectionWindow = _assetProvider.Initialize<LevelSelectionWindow>(AssetPath.LevelSelectionWindow);
            _allLevelsSettings = _assetProvider.Initialize<AllLevelsSettings>(AssetPath.AllLevelsSettings);
        }

        private void GetCurrentLevelSettings() =>
            _currentLevelSettings = _currentLevelSettingProvider.GetCurrentLevelSettings();
    }
}