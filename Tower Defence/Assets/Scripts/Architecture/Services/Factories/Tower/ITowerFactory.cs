using UnityEngine;

namespace Assets.Scripts.Architecture.Services.Factories.Tower
{
    public interface ITowerFactory
    {
        GameObject CreateTower(GameObject prefab, Vector3 at, Quaternion rotation, Transform parent);
        GameObject CreateTowerModel();
    }
}