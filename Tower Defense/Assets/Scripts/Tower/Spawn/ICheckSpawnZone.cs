using UnityEngine;

namespace Tower
{
    public interface ICheckSpawnZone
    {
        public RaycastHit CheckZone();
        public void ChangeTowerColor();
    }
}
