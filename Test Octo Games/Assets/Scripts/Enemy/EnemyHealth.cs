using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public int Health; /*{ get; private set; }*/

        public void TakeDamage(int damage) =>
            Health -= damage;
    }
}