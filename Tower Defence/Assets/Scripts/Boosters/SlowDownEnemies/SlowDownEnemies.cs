using System.Collections;
using Assets.Scripts.Architecture.Services.Factories.Enemies;
using Assets.Scripts.Architecture.States.Interfaces;
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
        private ICoroutineRunner _coroutineRunner;

        [Inject]
        public void Construct(IEnemyFactory enemyFactory, ICoroutineRunner coroutineRunner)
        {
            _enemyFactory = enemyFactory;
            _coroutineRunner = coroutineRunner;
        }

        public void SlowEnemies()
        {
            if (_enemyFactory.EnemyParent == null)
                return;
            
            foreach (Enemy.Main.Enemy enemy in _enemyFactory.EnemyParent.Enemies)
                enemy.GetComponent<NavMeshAgent>().speed /= _slowing;

            _coroutineRunner.StartCoroutine(StopSlowing());
        }

        private IEnumerator StopSlowing()
        {
            yield return new WaitForSeconds(_slowingDuration);

            foreach (Enemy.Main.Enemy enemy in _enemyFactory.EnemyParent.Enemies)
                enemy.GetComponent<NavMeshAgent>().speed = enemy.GetComponent<Enemy.Main.Enemy>().Speed;
        }
    }
}