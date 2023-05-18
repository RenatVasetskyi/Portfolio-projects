using System.Collections;
using Assets.Scripts.Architecture.Services.Factories.Enemies;
using Assets.Scripts.Tower.Characteristics;
using Assets.Scripts.Tower.Shooting;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Tower.Tracking
{
    public class EnemyTracking : MonoBehaviour
    {
        private const float UpdateTargetFrequency = 0.2f;

        [SerializeField] private Transform _cannonRotator;

        [SerializeField] private TowerCharacteristics _towerCharacteristics;
        [SerializeField] private TowerShooting _towerShooting;

        private float _fireCountDown = 0f;

        private IEnemyFactory _enemyFactory;

        public Transform Target { get; private set; }

        [Inject]
        public void Construct(IEnemyFactory enemyFactory) =>
            _enemyFactory = enemyFactory;

        private void Start() =>
            StartCoroutine(UpdateTarget());

        private void Update() =>
            Track();

        private IEnumerator UpdateTarget()
        {
            while (true)
            {
                float shortestDistance = Mathf.Infinity;
                GameObject nearestEnemy = null;

                shortestDistance = GetShotestDistance(shortestDistance, ref nearestEnemy);

                if (nearestEnemy != null && shortestDistance <= _towerCharacteristics.AttackRange)
                    Target = nearestEnemy.transform;
                else
                    Target = null;
                 
                yield return new WaitForSeconds(UpdateTargetFrequency);
            }
        }

        private float GetShotestDistance(float shortestDistance, ref GameObject nearestEnemy)
        {
            if (_enemyFactory.EnemyParent == null)
                return default;

            foreach (Enemy.Main.Enemy enemy in _enemyFactory.EnemyParent.Enemies)
            {
                float distanceToEnemy = GetDistanceToEnemy(enemy.gameObject);

                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy.gameObject;
                }
            }

            return shortestDistance;
        }

        private void Track()
        {
            if (Target == null)
                return;

            RotateTower();

            if (_fireCountDown <= 0)
            {
                _towerShooting.Shoot();
                _fireCountDown = 1f / _towerCharacteristics.FireSpeed;
            }

            _fireCountDown -= Time.deltaTime;
        }

        private void RotateTower()
        {
            Vector3 direction = Target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion
                .Lerp(_cannonRotator.rotation, lookRotation, Time.deltaTime * _towerCharacteristics.CannonRotateSpeed)
                .eulerAngles;
            _cannonRotator.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        private float GetDistanceToEnemy(GameObject enemy) =>
            Vector3.Distance(transform.position, enemy.transform.position);
    }
}
