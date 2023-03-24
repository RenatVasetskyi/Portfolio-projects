using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _cannonRotator;
    [SerializeField] private float _cannonRotateSpeed = 5f;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletStartPoint;   

    private TowerCharacteristics _towerCharacteristics;

    private Transform _target;

    private float _fireCountDown = 0f;

    private void Start()
    {
        _towerCharacteristics = GetComponent<TowerCharacteristics>();
        InvokeRepeating(nameof(UpdateTarget), 0f ,0.2f);
    }

    private void Update()
    {
        if (_target == null)       
            return;       

        Vector3 direction = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(_cannonRotator.rotation, lookRotation, Time.deltaTime * _cannonRotateSpeed).eulerAngles;
        _cannonRotator.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(_fireCountDown <= 0)
        {
            Shoot();
            _fireCountDown = 1f / _towerCharacteristics.FireSpeed;
        }

        _fireCountDown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(_bulletPrefab, _bulletStartPoint.position, _bulletStartPoint.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        if (bullet != null)        
            bullet.Seek(_target);       
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Constants.EnemyTag.ToString());
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            { 
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= _towerCharacteristics.AttackRange)       
            _target = nearestEnemy.transform;       
        else
            _target = null;
    }
}
