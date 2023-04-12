using ModestTree;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ShowTowerModel : MonoBehaviour
{
    [SerializeField] private LayerMask _spawnZoneLayer;

    private Ray _ray;
    private int _maxRayDistance = 200;

    private Vector2 _screenPosition;
    private Vector3 _worldPosition;

    private Dictionary<TowerType, GameObject> _createdModel = new Dictionary<TowerType, GameObject>();
    private bool _isModelCreated = false;

    private PlayerInput _input;
    private ButtonCreator _buttonCreator;

    [Inject]
    private void Construct(PlayerInput input, ButtonCreator buttonCreator)
    {
        _input = input;
        _buttonCreator = buttonCreator;
    }

    private void Show()
    {
        if (_buttonCreator.SelectedButton != null)
        {
            if (_isModelCreated == false)
            {
                GameObject model = Instantiate(_buttonCreator.SelectedButton.Tower.TowerModel);
                _createdModel.Clear();
                _createdModel.Add(_buttonCreator.SelectedButton.Tower.TowerType, model);
                _isModelCreated = true;
            }
            else
            {
                GameObject model = _createdModel.First().Value;
                model.gameObject.transform.position = _worldPosition;
            }

            if (_createdModel.First().Key != _buttonCreator.SelectedButton.Tower.TowerType)
            {
                Destroy(_createdModel.First().Value);
                _createdModel.Clear();
                GameObject towerModel = Instantiate(_buttonCreator.SelectedButton.Tower.TowerModel);
                _createdModel.Add(_buttonCreator.SelectedButton.Tower.TowerType, towerModel);
            }
        }
        else
        {
            if (!_createdModel.IsEmpty())
            {
                Destroy(_createdModel.First().Value);
                _createdModel.Clear();
                _isModelCreated = false;
            }
        }
    }

    private void LateUpdate()
    {
        _screenPosition = _input.Player.GetMousePosition.ReadValue<Vector2>();
        _ray = Camera.main.ScreenPointToRay(_screenPosition);

        if (Physics.Raycast(_ray, out RaycastHit hit))
        {
            _worldPosition = hit.point;
        }

        Show();
    }
}