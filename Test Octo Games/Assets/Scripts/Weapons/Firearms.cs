using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class Firearms : MonoBehaviour
    {
        [SerializeField] protected float _damage;
        [SerializeField] protected float _shotDistance;

        protected virtual void Shoot()
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _shotDistance))
                Hit();
        }

        protected virtual void Hit()
        {
            Debug.Log("Hit");
        }
    }
}