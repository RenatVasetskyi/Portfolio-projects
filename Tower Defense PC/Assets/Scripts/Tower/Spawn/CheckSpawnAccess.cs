using UnityEngine;

public class CheckSpawnAccess : MonoBehaviour
{
    [SerializeField] private LayerMask _spawnZoneLayer;

    private Ray _ray;
    private float _maxRaycastDistance = 200f;

    private Vector3 _screenPosition;

    public RaycastHit CheckAccess()
    {
        _ray = Camera.main.ScreenPointToRay(_screenPosition);

        if (Physics.Raycast(_ray, out RaycastHit hit, _maxRaycastDistance, _spawnZoneLayer))
        {            
            return hit;
        }
        else
        {
            return default;
        }
    }

    private void LateUpdate()
    {
        _screenPosition = Input.mousePosition;       
    }
}
