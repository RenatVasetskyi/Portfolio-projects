using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    public int Damage { get; set; }

    [SerializeField] private TowerInfo _towerInfo;   
    [SerializeField] private GameObject _destroyBulletEffect;

    private Transform _target;

    private float _destroyEffectDelay = 1f;
    private int _bulletSpeed;

    public void Initialize()
    {
        _bulletSpeed = _towerInfo.Bullet.Speed;
    }

    public void Seek(Transform target)
    {
        _target = target;
    }

    public void Move()
    {
        if (_target == null)
            return;

        Vector3 direction = _target.position - transform.position;
        float distanceThisFrame = _bulletSpeed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    public void CheckTarget()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void HitTarget()
    {
        Destroy(gameObject);

        GameObject effect = Instantiate(_destroyBulletEffect, transform.position, transform.rotation);
        Destroy(effect, _destroyEffectDelay);

        _target.GetComponent<VitalitySystem>().TakeDamage(Damage);
    }

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {      
        CheckTarget();
        Move();
    }  
}
