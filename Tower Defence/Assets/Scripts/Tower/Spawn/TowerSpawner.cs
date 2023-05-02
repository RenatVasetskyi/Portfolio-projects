using Assets.Scripts.Architecture.Services.Factories.Tower;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Tower.Selection;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Tower.Spawn
{
    public class TowerSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnZoneChecker _spawnZoneChecker;

        private ITowerFactory _towerFactory;
        private ILocalCoinService _localCoinService;
        private TowerSelection _towerSelection;

        private Vector3 _worldPosition;

        [Inject]
        public void Construct(ITowerFactory towerFactory, ILocalCoinService localCoinService, TowerSelection towerSelection)
        {
            _towerFactory = towerFactory;
            _localCoinService = localCoinService;
            _towerSelection = towerSelection;
        }

        public void SpawnTower()
        {
            _worldPosition = _spawnZoneChecker.CheckAccess().point;

            if (_worldPosition == default)
                return;

            if (_localCoinService.Coins >= _towerSelection.SelectedButton?.Tower.Price)
            {
                _localCoinService.Buy(_towerSelection.SelectedButton.Tower.Price);
                _towerFactory.CreateTower(_towerSelection.SelectedButton.Tower.TowerPrefab, _worldPosition, Quaternion.identity, transform);
            }
        }
    }
}