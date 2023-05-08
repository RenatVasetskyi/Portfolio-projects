using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Boosters;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Windows;
using Assets.Scripts.GameOver;
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
        private readonly IStaticDataService _staticData;
        private readonly ICurrentLevelSettingsProvider _currentLevelSettingProvider;

        private GameObject _levelSelectionWindow;

        private LevelTransferButtonMarker[] _markers;

        public TowerSelection TowerSelection { get; private set; }
        public BoosterHolder BoosterHolder { get; private set; }

        public UIFactory(DiContainer container, IAssetProvider assetProvider, IStaticDataService staticData, ICurrentLevelSettingsProvider currentLevelSettingProvider)
        {
            _container = container;
            _currentLevelSettingProvider = currentLevelSettingProvider;
            _assetProvider = assetProvider;
            _staticData = staticData;
        }

        public void CreateMainMenu()
        {
            Transform uiRoot = CreateUIRoot();

            MainMenu mainMenu = _assetProvider.Initialize<MainMenu>(AssetPath.MainMenuWindow);
            _container.InstantiatePrefabForComponent<MainMenu>(mainMenu, uiRoot);
        }

        public void CreateLevelSelectionWindow()
        {
            Transform uiRootCanvas = CreateUIRootCanvas();

            WindowConfig config = _staticData.ForWindow(WindowId.LevelSelection);
            _levelSelectionWindow = _container.InstantiatePrefab(config?.Prefab, uiRootCanvas);

            InitTransferButtonMarkers();
            CreateLevelTransferButton();
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

        private void CreateLevelTransferButton()
        {
            foreach (LevelTransferButtonMarker marker in _markers)
            {
                if (marker.IsOpened)
                {
                    LevelTransferButton button =
                        _container.InstantiatePrefabForComponent<LevelTransferButton>(_assetProvider.Initialize<LevelTransferButton>(AssetPath.LevelTransferButton),
                            marker.transform.position, Quaternion.identity, marker.transform);
                    button.LevelId = marker.Id;
                }
            }
        }

        private void CreateTowerSelectionButtons(TowerSelection towerSelection)
        {
            foreach (TowerSelectionButton button in _currentLevelSettingProvider.GetCurrentLevelSettings().TowerSelectionButtons.Buttons)
            {
                TowerSelectionButtonHolder spawnedButton = _container
                    .InstantiatePrefabForComponent<TowerSelectionButtonHolder>(button.ButtonPrefab, towerSelection.transform);

                spawnedButton.Tower = button.Tower;
                towerSelection.Buttons.Add(spawnedButton);
            }
        }

        private void CreateBoosterButtons()
        {
            foreach (BoosterButton boosterButton in _currentLevelSettingProvider.GetCurrentLevelSettings().Boosters)
            {
                BoosterButton spawnedBoosterButton = _container.
                    InstantiatePrefabForComponent<BoosterButton>(boosterButton, BoosterHolder.transform);

                BoosterHolder.BoosterButtons.Add(spawnedBoosterButton);
            }
        }

        private void CreateMainUIElements(Transform parent)
        {
            foreach (GameObject element in _currentLevelSettingProvider.GetCurrentLevelSettings().MainLevelUIElements)
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

        private Transform CreateUIRoot() => 
            Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.UIRoot));

        private Transform CreateUIRootCanvas() => 
            Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.UIRootCanvas));

        private void InitTransferButtonMarkers() => 
            _markers = _levelSelectionWindow.GetComponentsInChildren<LevelTransferButtonMarker>();
    }
}