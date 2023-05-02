using UnityEngine;

namespace Assets.Scripts.Architecture.Services.Factories.Tower.Bullet
{
    public interface IBulletFactory
    {
        GameObject CreateBullet(GameObject bullet, Vector3 at, Quaternion rotation, Transform parent);
    }
}