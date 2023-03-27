using UnityEngine;

public class SpawnZoneController : MonoBehaviour
{
    private ISpawnZone _spawnZone;

    private Vector3 _screenPosition;

    private void Awake()
    {
        _spawnZone = GetComponent<ISpawnZone>();
    }

    private void LateUpdate()
    {
        _screenPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(_screenPosition);

        _spawnZone.CheckAccess(ray);
    }
}
