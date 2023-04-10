using ModestTree;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class CheckSpawnAccess : MonoBehaviour
{
    [SerializeField] private LayerMask _spawnZoneLayer;
  
    private UIInteraction _uiInteraction;

    private Ray _ray;
    private float _maxRaycastDistance = 200f;

    private Vector2 _screenPosition;   

    [Inject]
    private void Construct(UIInteraction _uiInteraction)
    {
        this._uiInteraction = _uiInteraction;
    }  

    public RaycastHit CheckAccess()
    {
        _screenPosition = Mouse.current.position.ReadValue();
        _ray = Camera.main.ScreenPointToRay(_screenPosition);

        if (Physics.Raycast(_ray, out RaycastHit hit, _maxRaycastDistance, _spawnZoneLayer) & _uiInteraction.ClickResult.IsEmpty())                  
            return hit;       
        else       
            return default;        
    }
}
