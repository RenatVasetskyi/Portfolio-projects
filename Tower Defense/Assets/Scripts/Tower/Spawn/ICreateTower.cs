using UnityEngine;

namespace Tower
{
    public interface ICreateTower
    {
        public void CreateTower(Vector3 position, TowerType towerType);
    }
}
