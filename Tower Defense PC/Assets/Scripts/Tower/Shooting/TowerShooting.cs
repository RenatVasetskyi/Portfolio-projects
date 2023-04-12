using UnityEngine;

public class TowerShooting : MonoBehaviour, IShoot
{
    [SerializeField] private Transform _bulletStartPoint;
    
    private TowerCharacteristics _towerCharacteristics;
    private EnemyTracking _enemyTracking;

    public void Shoot()
    {
        var bulletObj = CreateBullet();
        var bullet = SetDamage(bulletObj);

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

    private GameObject CreateBullet()
    {
        GameObject bulletObj = Instantiate(_towerCharacteristics.Tower.Bullet.Prefab, _bulletStartPoint.position,
            _bulletStartPoint.rotation);
        return bulletObj;
    }
}
