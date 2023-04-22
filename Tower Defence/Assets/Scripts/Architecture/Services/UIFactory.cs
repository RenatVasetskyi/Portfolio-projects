using Assets.Scripts.Data;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Services
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;

        private Transform _mainMenuCanvas;

        public UIFactory(IAssetProvider assetProvider, IStaticDataService staticData, DiContainer container)
        {
            _container = container;
            _assetProvider = assetProvider;
            _staticData = staticData;
        }

        public void CreateMainMenu()
        {
            _mainMenuCanvas = _container.InstantiatePrefab(_assetProvider.Initialize<GameObject>(AssetPath.MainMenuCanvas)).transform;
            CreateMainWindow();
        }

        public void CreateMainWindow() =>
            _container.InstantiatePrefab(_assetProvider.Initialize<GameObject>(AssetPath.MainWindow), _mainMenuCanvas);

        public GameObject CreateLevelSelectionWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.LevelSelection);

            return _container.InstantiatePrefab(config?.Prefab, _mainMenuCanvas);
        }
    }
}