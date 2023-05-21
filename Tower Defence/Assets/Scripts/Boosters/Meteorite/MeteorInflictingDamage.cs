using Assets.Scripts.Enemy.Health;
using UnityEngine;

namespace Assets.Scripts.Boosters.Meteorite
{
    public class MeteorInflictingDamage : MonoBehaviour
    {
        [SerializeField] private int _damage;

        private void OnTriggerEnter(Collider other) =>
            other.GetComponent<EnemyHealth>().TakeDamage(_damage);
    }
}