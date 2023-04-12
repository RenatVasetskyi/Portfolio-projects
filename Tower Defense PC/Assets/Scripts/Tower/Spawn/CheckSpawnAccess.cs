using UnityEngine;
using UnityEngine.InputSystem;

public class CheckSpawnAccess : MonoBehaviour
{
    private readonly int _maxRaycastDistance = 200;
    
    [SerializeField] private LayerMask _spawnZoneLayer;
    [SerializeField] private LayerMask _towerLayer;

    private Ray _ray;

    private Vector2 _screenPosition;   

    public RaycastHit CheckAccess()
    {
        GetScreenPosition();

        if (Physics.Raycast(_ray, out RaycastHit hit, _maxRaycastDistance, _spawnZoneLayer) & !Physics.Raycast(_ray, _maxRaycastDistance, _towerLayer))                  
            return hit;       
        else       
            return default;
    }

    private void GetScreenPosition()
    {
        _screenPosition = Mouse.current.position.ReadValue();
        _ray = Camera.main.ScreenPointToRay(_screenPosition);
    }
}
