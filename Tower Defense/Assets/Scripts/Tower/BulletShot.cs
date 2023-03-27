using UnityEngine;

public class BulletShot : MonoBehaviour, IBulletShot
{
    public float Damage;

    [SerializeField] private float _bulletSpeed;
    [SerializeField] private GameObject _destroyBulletEffect;

    private IBulletShot _bulletShot;

    private Transform _target;

    private float _destroyEffectDelay = 1f;

    private void Awake()
    {
        _bulletShot = GetComponent<IBulletShot>();
    }

    void IBulletShot.Seek(Transform target)
    {
        _target = target;
    }

    void IBulletShot.Move()
    {
        if (_target == null)
            return;

        Vector3 direction = _target.position - transform.position;
        float distanceThisFrame = _bulletSpeed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            _bulletShot.HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void IBulletShot.CheckTarget()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }
    }

    void IBulletShot.HitTarget()
    {
        Destroy(gameObject);

        GameObject effect = Instantiate(_destroyBulletEffect, transform.position, transform.rotation);
        Destroy(effect, _destroyEffectDelay);

        _target.GetComponent<VitalitySystem>().TakeDamage(Damage);
    }
}
