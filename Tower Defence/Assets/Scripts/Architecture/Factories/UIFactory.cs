using System.Linq;
using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Data;
using Assets.Scripts.UI;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Architecture.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;

        private Transform _rootCanvas;
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
            CreateRootCanvas();
            MainMenu mainMenu = _assetProvider.Initialize<MainMenu>(AssetPath.MainWindow);
            Object.Instantiate(mainMenu, _rootCanvas);
        }

        public void CreateLevelSelectionWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.LevelSelection);
            _levelSelectionWindow = _container.InstantiatePrefab(config?.Prefab, _rootCanvas);

            InitTransferButtonMarkers();
            CreateLevelTransferButton();
        }

        private void CreateRootCanvas() =>
            Object.Instantiate(_assetProvider.Initialize<GameObject>(AssetPath.MainMenuCanvas));

        private void CreateLevelTransferButton()
        {
            ButtonConfig buttonConfig = _staticData.ForButton(_markers.Select(x => x.Id).FirstOrDefault());
            LevelTransferButton button = _container.InstantiatePrefabForComponent<LevelTransferButton>(buttonConfig.Prefab, _levelSelectionWindow.transform);
            button.LevelId = buttonConfig.Id;
        }

        private void InitTransferButtonMarkers() => 
            _markers = _levelSelectionWindow.GetComponentsInChildren<LevelTransferButtonMarker>();
    }
}