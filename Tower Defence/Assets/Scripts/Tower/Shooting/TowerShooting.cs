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

        [SerializeField] private TowerCharacteristics _towerCharacteristics;
        [SerializeField] private EnemyTracking _enemyTracking;

        [Inject]
        public void Construct(IBulletFactory bulletFactory, IAudioService audioService)
        {
            _bulletFactory = bulletFactory;
            _audioService = audioService;
        }

        public void Shoot()
        {
            _audioService.PlaySfx(_shotSfxType);

            Bullet bullet = _bulletFactory
                .CreateBullet(_towerCharacteristics.Tower.Bullet.Prefab, _bulletStartPoint.position, _bulletStartPoint.rotation, transform);
            bullet.Damage = _towerCharacteristics.Damage;

            bullet.BulletCheckTarget.Seek(_enemyTracking.Target);
        }
    }
}