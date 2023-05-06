using Assets.Scripts.Architecture.Services.Factories.Tower;
using Assets.Scripts.Architecture.Services.Factories.UI;
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
        private ILevelUIFactory _levelUIFactory;

        private Vector3 _worldPosition;

        [Inject]
        public void Construct(ITowerFactory towerFactory, ILocalCoinService localCoinService, PlayerInput input, ILevelUIFactory levelUIFactory)
        {
            _towerFactory = towerFactory;
            _localCoinService = localCoinService;
            _levelUIFactory = levelUIFactory;
            input.Player.CreateTower.performed += context => SpawnTower();
        }

        public void SpawnTower()
        {
            if (IsPointerOverUI())
                return;

            _worldPosition = _spawnZoneChecker.CheckAccess().point;

            if (_worldPosition == default)
                return;

            if (_localCoinService.Coins >= _levelUIFactory.TowerSelection.SelectedButton?.Tower.Price)
            {
                _localCoinService.Buy(_levelUIFactory.TowerSelection.SelectedButton.Tower.Price);
                _towerFactory.CreateTower(_levelUIFactory.TowerSelection.SelectedButton.Tower.TowerPrefab, _worldPosition, Quaternion.identity, transform);
            }
        }

        private bool IsPointerOverUI()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return true;
            else
                return false;
        }
    }
}