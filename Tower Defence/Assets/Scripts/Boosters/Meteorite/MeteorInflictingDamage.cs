using Assets.Scripts.Data;
using Assets.Scripts.Enemy.Health;
using UnityEngine;

namespace Assets.Scripts.Boosters.Meteorite
{
    public class MeteorInflictingDamage : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private Meteor _booster;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Tags.Enemy)
                other.GetComponent<EnemyHealth>().TakeDamage(_damage);
        }
    }
}