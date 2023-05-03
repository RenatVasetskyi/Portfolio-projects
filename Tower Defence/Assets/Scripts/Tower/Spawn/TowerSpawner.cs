using Assets.Scripts.Architecture.Services.Factories.Tower;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Tower.Selection;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.Scripts.Tower.Spawn
{
    public class TowerSpawner : MonoBehaviour
    { 
        private SpawnZoneChecker _spawnZoneChecker = new();

        private ITowerFactory _towerFactory;
        private ILocalCoinService _localCoinService;
        private TowerSelection _towerSelection;

        private Vector3 _worldPosition;

        [Inject]
        public void Construct(ITowerFactory towerFactory, ILocalCoinService localCoinService, TowerSelection towerSelection, PlayerInput input)
        {
            _towerFactory = towerFactory;
            _localCoinService = localCoinService;
            _towerSelection = towerSelection;
            input.Player.CreateTower.performed += context => SpawnTower();
        }

        public void SpawnTower()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

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