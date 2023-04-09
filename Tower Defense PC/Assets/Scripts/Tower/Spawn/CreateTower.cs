using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class CreateTower : MonoBehaviour
{
    [SerializeField] private ButtonCreator _buttonCreator;
    [SerializeField] private CheckSpawnAccess _spawnAccess;
    [SerializeField] private UICoins _coinsUI;

    private LocalCoinService _localCoinService;   

    private Vector3 _worlPosition;

    [Inject]
    private void Construct(LocalCoinService localCoinService, PlayerInput input)
    {
        _localCoinService = localCoinService;
        input.Player.CreateTower.performed += context => Create();
    }

    private void Create()
    {
        _worlPosition = _spawnAccess.CheckAccess().point;

        if (_spawnAccess.CheckAccess().point == default)
        {
            return;
        }

        if (_localCoinService.Coins >= _buttonCreator.SelectedButton?.Tower.Price)
        {          

            Instantiate(_buttonCreator.SelectedButton.Tower.TowerPrefab, _worlPosition, Quaternion.identity, transform);

            _localCoinService.Coins -= _buttonCreator.SelectedButton.Tower.Price;
            _coinsUI.OnCoinsChanged.Invoke();
        }
    }
}
