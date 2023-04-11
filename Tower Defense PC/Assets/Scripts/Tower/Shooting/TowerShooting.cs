using UnityEngine;

public class TowerShooting : MonoBehaviour, IShoot
{
    [SerializeField] private Transform _bulletStartPoint;
    
    private TowerCharacteristics _towerCharacteristics;
    private EnemyTracking _enemyTracking;

    public void Shoot()
    {
        GameObject bulletObj = Instantiate(_towerCharacteristics.Tower.Bullet.Prefab, _bulletStartPoint.position, _bulletStartPoint.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.Damage = _towerCharacteristics.Damage;

        if (bullet != null)
            bullet.Seek(_enemyTracking.Target);
    }

    private void Awake()
    {
        _enemyTracking = GetComponent<EnemyTracking>();
        _towerCharacteristics = GetComponent<TowerCharacteristics>();
    }
}
