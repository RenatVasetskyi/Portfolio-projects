using Assets.Scripts.Tower.Selection;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Services.Factories.Tower
{
    public class TowerFactory : ITowerFactory
    {
        private readonly DiContainer _container;
        private readonly TowerSelection _towerSelection;

        public TowerFactory(DiContainer container, TowerSelection towerSelection)
        {
            _container = container;
            _towerSelection = towerSelection;
        }

        public GameObject CreateTower(GameObject prefab, Vector3 at, Quaternion rotation, Transform parent) =>
            _container.InstantiatePrefab(prefab, at, rotation, parent);

        public GameObject CreateTowerModel() =>
            Object.Instantiate(_towerSelection.SelectedButton.Tower.TowerModel);
    }
}