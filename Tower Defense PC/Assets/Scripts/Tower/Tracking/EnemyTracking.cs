using UnityEngine;

public class EnemyTracking : MonoBehaviour, IEnemyTracking
{   
    [SerializeField] private Transform _cannonRotator;    

    private TowerCharacteristics _towerCharacteristics;  

    private float _fireCountDown = 0f;

    private TowerShooting _towerShooting;

    public Transform Target { get; private set; }

    public void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.EnemyTag.ToString());
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
            Target = nearestEnemy.transform;
        else
            Target = null;
    }

    public void Track()
    {
        if (Target == null)
            return;

        Vector3 direction = Target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(_cannonRotator.rotation, lookRotation, Time.deltaTime * _towerCharacteristics.CannonRotateSpeed).eulerAngles;
        _cannonRotator.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (_fireCountDown <= 0)
        {
            _towerShooting.Shoot();
            _fireCountDown = 1f / _towerCharacteristics.FireSpeed;
        }

        _fireCountDown -= Time.deltaTime;
    }

    private void Awake()
    {
        _towerShooting = GetComponent<TowerShooting>();
        _towerCharacteristics = GetComponent<TowerCharacteristics>();
    }

    private void Update()
    {
        Track();
        UpdateTarget();
    }
}


