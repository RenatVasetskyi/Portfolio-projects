using UnityEngine;

namespace Environment
{
    public class SpawnZoneController : MonoBehaviour
    {
        private ICheckSpawnAccess _spawnAccess;

        private void Awake()
        {
            _spawnAccess = GetComponent<ICheckSpawnAccess>();
        }

        private void LateUpdate()
        {
            _spawnAccess.CheckAccess();
        }
    }
}
