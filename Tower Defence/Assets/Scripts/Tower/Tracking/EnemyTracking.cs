using Assets.Scripts.Data;
using Assets.Scripts.Tower.Characteristics;
using Assets.Scripts.Tower.Shooting;
using UnityEngine;

namespace Assets.Scripts.Tower.Tracking
{
    public class EnemyTracking : MonoBehaviour
    {
        [SerializeField] private Transform _cannonRotator;

        [SerializeField] private TowerCharacteristics _towerCharacteristics;
        [SerializeField] private TowerShooting _towerShooting;

        private float _fireCountDown = 0f;

        public Transform Target { get; private set; }

        private void Update()
        {
            Track();
            UpdateTarget();
        }

        private void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.Enemy);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance <= _towerCharacteristics.AttackRange)
                Target = nearestEnemy.transform;
            else
                Target = null;
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
    }
}
