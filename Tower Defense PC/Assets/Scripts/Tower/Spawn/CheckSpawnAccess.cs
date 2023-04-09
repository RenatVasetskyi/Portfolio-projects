using ModestTree;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class CheckSpawnAccess : MonoBehaviour
{
    [SerializeField] private LayerMask _spawnZoneLayer;
  
    private UIInteraction ui_interaction;

    private Ray _ray;
    private float _maxRaycastDistance = 200f;

    private Vector2 _screenPosition;   

    [Inject]
    private void Construct(UIInteraction ui_interaction)
    {
        this.ui_interaction = ui_interaction;
    }  

    public RaycastHit CheckAccess()
    {
        _screenPosition = Mouse.current.position.ReadValue();
        _ray = Camera.main.ScreenPointToRay(_screenPosition);

        if (Physics.Raycast(_ray, out RaycastHit hit, _maxRaycastDistance, _spawnZoneLayer) & ui_interaction.ClickResult.IsEmpty())                  
            return hit;       
        else       
            return default;        
    }
}
