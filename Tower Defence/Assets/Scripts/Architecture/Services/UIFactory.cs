using System.Collections.Generic;
using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;

        private Dictionary<WindowId, WindowConfig> _windows;
        private Transform _uiRoot;

        public UIFactory(IAssetProvider assetProvider, IStaticDataService staticData)
        {
            _assetProvider = assetProvider;
            _staticData = staticData;
        }

        public GameObject CreateWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.LevelSelection);
            return Object.Instantiate(config.Prefab, _uiRoot);
        }

        public void CreateUIRoot() =>
            _uiRoot = _assetProvider.Initialize<Transform>(AssetPath.UIRoot).transform;
    }
}