using UnityEngine;

public class SpawnZoneController : MonoBehaviour
{
    private ISpawnZone _spawnZone;

    private void Awake()
    {
        _spawnZone = GetComponent<ISpawnZone>();
    }

    private void LateUpdate()
    {      
        _spawnZone.CheckAccess();
    }
}
