using Assets.Scripts.Architecture.Services.Factories.Tower;
using Assets.Scripts.Architecture.Services.Interfaces;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Tower.Spawn
{
    public class TowerSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnZoneChecker _spawnZoneChecker;

        private ITowerFactory _towerFactory;
        private ILocalCoinService _localCoinService;

        private Vector3 _worldPosition;

        [Inject]
        public void Construct(ITowerFactory towerFactory, ILocalCoinService localCoinService)
        {
            _towerFactory = towerFactory;
            _localCoinService = localCoinService;
        }

        public void SpawnTower()
        {
            _worldPosition = _spawnZoneChecker.CheckAccess().point;

            if (_spawnZoneChecker.CheckAccess().point == default)
                return;

            //if (_localCoinService.Coins >= _buttonCreator.SelectedButton?.Tower.Price)
            //{
            //    //_localCoinService.Buy(_buttonCreator.SelectedButton.Tower.Price);
            //    //_towerFactory.CreateTower(_buttonCreator.SelectedButton.Tower.Prefab);
            //}
        }
    }
}