using Assets.Scripts.Architecture.Services.Factories.Tower.Bullet;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Audio;
using Assets.Scripts.Tower.Bullets;
using Assets.Scripts.Tower.Characteristics;
using Assets.Scripts.Tower.Tracking;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Tower.Shooting
{
    public class TowerShooting : MonoBehaviour
    {
        [SerializeField] private SfxType _shotSfxType;
        [SerializeField] private Transform _bulletStartPoint;

        private IBulletFactory _bulletFactory;
        private IAudioService _audioService;

        private TowerCharacteristics _towerCharacteristics;
        private EnemyTracking _enemyTracking;

        [Inject]
        public void Construct(IBulletFactory bulletFactory, IAudioService audioService)
        {
            _bulletFactory = bulletFactory;
            _audioService = audioService;
        }

        public void Shoot()
        {
            _audioService.PlaySfx(_shotSfxType);
            GameObject bulletObj = _bulletFactory
                .CreateBullet(_towerCharacteristics.Tower.Bullet.Prefab, _bulletStartPoint.position, _bulletStartPoint.rotation, transform);
            Bullet bullet = SetDamage(bulletObj);

            if (bullet != null)
                bullet.GetComponent<BulletCheckTarget>().Seek(_enemyTracking.Target);
        }

        private void Awake()
        {
            _enemyTracking = GetComponent<EnemyTracking>();
            _towerCharacteristics = GetComponent<TowerCharacteristics>();
        }

        private Bullet SetDamage(GameObject bulletObj)
        {
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bullet.Damage = _towerCharacteristics.Damage;
            return bullet;
        }
    }
}