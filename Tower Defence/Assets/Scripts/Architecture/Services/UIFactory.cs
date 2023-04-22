using System.Collections.Generic;
using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;

        private Dictionary<WindowId, WindowConfig> _windows;
        private Transform _uiRoot;

        public UIFactory(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public GameObject CreateWindow() =>
            Object.Instantiate(_assetProvider.Initialize<GameObject>(AssetPath.UIWindows), _uiRoot);

        public void CreateUIRoot() =>
            _uiRoot = _assetProvider.Initialize<Transform>(AssetPath.UIRoot).transform;
    }
}