using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy.Main
{
    public class EnemyParent : MonoBehaviour
    {
        public List<Enemy> Enemies { get; set; } = new();

        public void DestroyEnemies() =>
            Destroy(gameObject);
    }
}