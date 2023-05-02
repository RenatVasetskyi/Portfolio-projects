using Assets.Scripts.Enemy.Health;
using UnityEngine;

namespace Assets.Scripts.Tower.Bullet
{
    public class BulletHitTarget : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private BulletCheckTarget _checkTarget;
        [SerializeField] private BulletDestroyEffect _destroyEffect;

        public void Hit()
        {
            Destroy(gameObject);
            _destroyEffect.PlayEffect();
            _checkTarget.Target.GetComponent<EnemyHealth>().TakeDamage(_bullet.Damage);
        }
    }
}
