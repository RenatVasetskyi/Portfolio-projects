using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Boosters;
using Assets.Scripts.Data;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Services.Factories.Booster
{
    public class BoosterFactory : IBoosterFactory
    {
        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;

        public BoosterFactory(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
        }

        public Boosters.Booster CreateBooster(BoosterType boosterType, Vector3 at, Quaternion rotation, Transform parent)
        {
            switch (boosterType)
            {
                case BoosterType.Meteor: 
                   Boosters.Booster booster = _container.InstantiatePrefabForComponent<Boosters.Booster>(
                        _assetProvider.Initialize<Boosters.Booster>(AssetPath.MeteorBooster), at, rotation, parent);
                   return booster;
            }

            return null;
        }
    }
}