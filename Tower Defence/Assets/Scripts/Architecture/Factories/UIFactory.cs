using System.Linq;
using Assets.Scripts.Architecture.Main;
using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.States.Interfaces;
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
        private readonly IStateMachine _stateMachine;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;

        private Transform _mainMenuCanvas;
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
            _mainMenuCanvas = Object.Instantiate(_assetProvider.Initialize<GameObject>(AssetPath.MainMenuCanvas)).transform;
            CreateMainWindow();
        }

        public void CreateMainWindow() =>
            _container.InstantiatePrefab(_assetProvider.Initialize<GameObject>(AssetPath.MainWindow), _mainMenuCanvas);

        public void CreateLevelSelectionWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.LevelSelection); 
            _levelSelectionWindow = _container.InstantiatePrefab(config?.Prefab, _mainMenuCanvas);

            InitTransferButtonMarkers();
            CreateLevelTransferButton();
        }

        public void CreateLevelTransferButton()
        {
            ButtonConfig buttonConfig = _staticData.ForButton(_markers.Select(x => x.Id).FirstOrDefault());
            GameObject button = _container.InstantiatePrefab(buttonConfig.Prefab, _levelSelectionWindow.transform);
            button.AddComponent<LevelTransferButton>().LevelId = buttonConfig.Id;
        }

        public void InitTransferButtonMarkers() => 
            _markers = _levelSelectionWindow.GetComponentsInChildren<LevelTransferButtonMarker>();
    }
}