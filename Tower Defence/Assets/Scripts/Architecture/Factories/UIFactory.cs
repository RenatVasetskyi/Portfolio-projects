using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Levels;
using Assets.Scripts.UI;
using Assets.Scripts.UI.OnLevel.Coins;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Architecture.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;
        private readonly AllLevelsSettings _levels;

        private GameObject _levelSelectionWindow;

        private LevelTransferButtonMarker[] _markers;

        public UIFactory(IAssetProvider assetProvider, IStaticDataService staticData, DiContainer container, AllLevelsSettings levels)
        {
            _container = container;
            _assetProvider = assetProvider;
            _staticData = staticData;
            _levels = levels;
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
            LevelSettings currentLevel = GetCurrentLevel();
            Transform parent = CreateUIRootCanvas();

            CreateLevelButtonForComponent<ShowCoinsCount>(currentLevel.CoinsCounter, parent);
            CreateLevelButton(currentLevel.StartWavesButton, parent);
            CreateLevelButton(currentLevel.WaveCounter, parent);
            CreateLevelButton(currentLevel.PlayersHp, parent);
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

        private void CreateLevelButtonForComponent<T>(GameObject button, Transform parent)
        {
            if (button != null)
                _container.InstantiatePrefabForComponent<T>(button, parent);
        }

        private void CreateLevelButton(GameObject button, Transform parent)
        {
            if (button != null)
                _container.InstantiatePrefab(button, parent);
        }

        private Transform CreateUIRoot() => 
            Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.UIRoot));

        private Transform CreateUIRootCanvas() => 
            Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.UIRootCanvas));

        private void InitTransferButtonMarkers() => 
            _markers = _levelSelectionWindow.GetComponentsInChildren<LevelTransferButtonMarker>();

        private LevelSettings GetCurrentLevel() =>
            _levels.Levels.Find(x => x.Id.ToString() == SceneManager.GetActiveScene().name);
    }
}