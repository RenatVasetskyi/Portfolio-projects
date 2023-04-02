using UnityEngine;
using Vitality;

namespace Bullet
{
    public class BulletShot : MonoBehaviour, IBulletShot
    {
        public float Damage;

        [SerializeField] private float _bulletSpeed;
        [SerializeField] private GameObject _destroyBulletEffect;

        private Transform _target;

        private float _destroyEffectDelay = 1f;

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
    }
}