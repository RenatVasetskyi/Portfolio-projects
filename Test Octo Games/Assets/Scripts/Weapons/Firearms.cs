using Assets.Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class Firearms : MonoBehaviour
    {
        [SerializeField] protected int _damage;
        [SerializeField] protected float _shotDistance;
        [SerializeField] protected LayerMask _enemyLayer;

        protected virtual void Shoot()
        {
            Debug.Log("SHOT");
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _shotDistance, _enemyLayer))
                Hit(hit);
        }

        protected virtual void Hit(RaycastHit hit)
        {
            hit.transform.GetComponent<EnemyHealth>().TakeDamage(_damage);
            Debug.Log("HIT");
        }
    }
}