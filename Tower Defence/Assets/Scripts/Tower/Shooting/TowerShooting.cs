using Assets.Scripts.Architecture.Services.Factories.Tower.Bullet;
using Assets.Scripts.Tower.Bullet;
using Assets.Scripts.Tower.Characteristics;
using Assets.Scripts.Tower.Tracking;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Tower.Shooting
{
    public class TowerShooting : MonoBehaviour
    {
        [SerializeField] private Transform _bulletStartPoint;

        private IBulletFactory _bulletFactory;

        private TowerCharacteristics _towerCharacteristics;
        private EnemyTracking _enemyTracking;

        [Inject]
        public void Construct(IBulletFactory bulletFactory) =>
            _bulletFactory = bulletFactory;

        public void Shoot()
        {
            GameObject bulletObj = _bulletFactory
                .CreateBullet(_towerCharacteristics.Tower.Bullet.Prefab, _bulletStartPoint.position, _bulletStartPoint.rotation, transform);
            Bullet.Bullet bullet = SetDamage(bulletObj);

            if (bullet != null)
                bullet.GetComponent<BulletCheckTarget>().Seek(_enemyTracking.Target);
        }

        private void Awake()
        {
            _enemyTracking = GetComponent<EnemyTracking>();
            _towerCharacteristics = GetComponent<TowerCharacteristics>();
        }

        private Bullet.Bullet SetDamage(GameObject bulletObj)
        {
            Bullet.Bullet bullet = bulletObj.GetComponent<Bullet.Bullet>();
            bullet.Damage = _towerCharacteristics.Damage;
            return bullet;
        }
    }
}