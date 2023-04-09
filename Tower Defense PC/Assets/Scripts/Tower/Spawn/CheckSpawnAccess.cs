using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CheckSpawnAccess : MonoBehaviour
{
    [SerializeField] private LayerMask _spawnZoneLayer;  

    private Ray _ray;
    private float _maxRaycastDistance = 200f;

    private Vector2 _screenPosition;  

    public RaycastHit CheckAccess()
    {
        _screenPosition = Mouse.current.position.ReadValue();
        _ray = Camera.main.ScreenPointToRay(_screenPosition);

        if (Physics.Raycast(_ray, out RaycastHit hit, _maxRaycastDistance, _spawnZoneLayer)/* & !EventSystem.current.IsPointerOverGameObject()*/)                  
            return hit;       
        else       
            return default;        
    }
}
