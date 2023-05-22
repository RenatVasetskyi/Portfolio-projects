using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Services.Factories.Tower.Bullet
{
    public class BulletFactory : IBulletFactory
    {
        private readonly DiContainer _container;

        public BulletFactory(DiContainer container) =>
            _container = container;

        public Scripts.Tower.Bullets.Bullet CreateBullet(GameObject bullet, Vector3 at, Quaternion rotation, Transform parent) =>
            _container.InstantiatePrefabForComponent<Scripts.Tower.Bullets.Bullet>(bullet, at, rotation, parent);
    }
}