using ModestTree;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ShowTowerModel : MonoBehaviour
{   
    private readonly Dictionary<TowerType, GameObject> _createdModel = new Dictionary<TowerType, GameObject>();
    
    private Ray _ray;
   
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;

    private bool _isModelCreated = false;

    private PlayerInput _input;
    private ButtonCreator _buttonCreator;

    [Inject]
    private void Construct(PlayerInput input, ButtonCreator buttonCreator)
    {
        _input = input;
        _buttonCreator = buttonCreator;
    }
    
    private void LateUpdate()
    {
        GetWorldPosition();
        Show();
    }

    private void Show()
    {
        if (_buttonCreator.SelectedButton != null)
        {
            if (_isModelCreated == false)
            {
                CreateModel();
                AddToSpawned();
            }
            else
            {
                MoveModel();
            }

            if (_createdModel.First().Key != _buttonCreator.SelectedButton.Tower.TowerType)
            {
                ChangeModel();
            }
        }
        else
        {
            if (!_createdModel.IsEmpty())
            {
                DestroyModel();
            }
        }
    }

    private void DestroyModel()
    {
        Destroy(_createdModel.First().Value);
        _createdModel.Clear();
        _isModelCreated = false;
    }

    private void ChangeModel()
    {
        Destroy(_createdModel.First().Value);
        _createdModel.Clear();
        GameObject towerModel = Instantiate(_buttonCreator.SelectedButton.Tower.TowerModel);
        _createdModel.Add(_buttonCreator.SelectedButton.Tower.TowerType, towerModel);
    }

    private void MoveModel()
    {
        GameObject model = _createdModel.First().Value;
        model.gameObject.transform.position = _worldPosition;
    }

    private void AddToSpawned()
    {
        _createdModel.Clear();
        _createdModel.Add(_buttonCreator.SelectedButton.Tower.TowerType, CreateModel());
    }

    private GameObject CreateModel()
    {
        _isModelCreated = true;
        return Instantiate(_buttonCreator.SelectedButton.Tower.TowerModel);
    }
    
    private void GetWorldPosition()
    {
        _screenPosition = _input.Player.GetMousePosition.ReadValue<Vector2>();
        _ray = Camera.main.ScreenPointToRay(_screenPosition);

        if (Physics.Raycast(_ray, out RaycastHit hit))
        {
            _worldPosition = hit.point;
        }
    }
}