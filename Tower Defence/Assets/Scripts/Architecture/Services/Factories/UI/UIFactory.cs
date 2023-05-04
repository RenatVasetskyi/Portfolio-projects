using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Windows;
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

        private GameObject _levelSelectionWindow;

        private LevelTransferButtonMarker[] _markers;

        public UIFactory(IAssetProvider assetProvider, IStaticDataService staticData, DiContainer container)
        {
            _container = container;
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

        private Transform CreateUIRoot() => 
            Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.UIRoot));

        private Transform CreateUIRootCanvas() => 
            Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.UIRootCanvas));

        private void InitTransferButtonMarkers() => 
            _markers = _levelSelectionWindow.GetComponentsInChildren<LevelTransferButtonMarker>();
    }
}