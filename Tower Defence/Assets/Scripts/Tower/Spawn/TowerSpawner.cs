using Assets.Scripts.Architecture.Services.Factories.Tower;
using Assets.Scripts.Architecture.Services.Factories.UI;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Audio;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.Scripts.Tower.Spawn
{
    public class TowerSpawner : MonoBehaviour
    { 
        private SpawnZoneChecker _spawnZoneChecker = new();

        private ITowerFactory _towerFactory;
        private ILocalCoinService _localCoinService;
        private IUIFactory _uiFactory;
        private IAudioService _audioService;
        private PlayerInput _input;

        private Vector3 _worldPosition;

        [Inject]
        public void Construct(ITowerFactory towerFactory, ILocalCoinService localCoinService, PlayerInput input, IUIFactory uiFactory, IAudioService audioService)
        {
            _towerFactory = towerFactory;
            _localCoinService = localCoinService;
            _uiFactory = uiFactory;
            _audioService = audioService;
            _input = input;
        }

        public void SpawnTower(InputAction.CallbackContext context)
        {
            if (IsPointerOverUI())
                return;

            _worldPosition = _spawnZoneChecker.CheckAccess().point;

            if (_worldPosition == default)
                return;

            if (_localCoinService.Coins >= _uiFactory.TowerSelection.SelectedButton?.Tower.Price)
            {
                _audioService.PlaySfx(SfxType.SpawnTower);
                _localCoinService.Buy(_uiFactory.TowerSelection.SelectedButton.Tower.Price);
                _towerFactory.CreateTower(_uiFactory.TowerSelection.SelectedButton.Tower.TowerPrefab, _worldPosition, Quaternion.identity, transform);
            }
        }

        private void Awake() =>
            _spawnZoneChecker.Camera = UnityEngine.Camera.main;

        private void OnEnable() =>
            _input.Player.CreateTower.performed += SpawnTower;

        private void OnDisable() =>
            _input.Player.CreateTower.performed -= SpawnTower;

        private bool IsPointerOverUI()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return true;
            else
                return false;
        }
    }
}