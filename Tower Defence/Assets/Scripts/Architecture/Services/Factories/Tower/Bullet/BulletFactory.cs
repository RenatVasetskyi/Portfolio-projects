using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Services.Factories.Tower.Bullet
{
    public class BulletFactory : IBulletFactory
    {
        private readonly DiContainer _container;

        public BulletFactory(DiContainer container) =>
            _container = container;

        public GameObject CreateBullet(GameObject bullet, Vector3 at, Quaternion rotation, Transform parent) =>
            _container.InstantiatePrefab(bullet, at, rotation, parent);
    }
}