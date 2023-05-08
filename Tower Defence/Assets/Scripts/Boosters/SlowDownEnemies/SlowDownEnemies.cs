using System.Collections;
using Assets.Scripts.Architecture.Services.Factories.Enemy;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Assets.Scripts.Boosters.SlowDownEnemies
{
    public class SlowDownEnemies : MonoBehaviour
    {
        [SerializeField] private float _slowingDuration;
        [SerializeField] private float _slowing;

        private IEnemyFactory _enemyFactory;

        [Inject]
        public void Construct(IEnemyFactory enemyFactory) =>
            _enemyFactory = enemyFactory;

        public void SlowEnemies()
        {
            if (_enemyFactory.EnemyParent == null)
                return;
            
            foreach (GameObject enemy in _enemyFactory.EnemyParent.Enemies)
                enemy.GetComponent<NavMeshAgent>().speed /= _slowing;

            StartCoroutine(StopSlowing());
        }

        private IEnumerator StopSlowing()
        {
            yield return new WaitForSeconds(_slowingDuration);

            foreach (GameObject enemy in _enemyFactory.EnemyParent.Enemies)
                enemy.GetComponent<NavMeshAgent>().speed = enemy.GetComponent<Enemy.Main.Enemy>().EnemyData.Speed;
        }
    }
}