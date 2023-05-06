using Assets.Scripts.Data;
using Assets.Scripts.Enemy.Health;
using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class BoosterInflictingDamage : MonoBehaviour
    {
        [SerializeField] private Booster _booster;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Tags.Enemy)
                other.GetComponent<EnemyHealth>().TakeDamage(_booster.Damage);
        }
    }
}