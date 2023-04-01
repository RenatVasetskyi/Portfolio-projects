using UnityEngine;
using Events;

namespace Vitality
{
    public class VitalitySystem : MonoBehaviour
    {
        [SerializeField] protected HealthBarController _healthBarController;

        [SerializeField] protected float _maxHp;
        [SerializeField] protected float _currentHp;
        [SerializeField] protected float _minHp;

        public void TakeDamage(float damage)
        {
            _currentHp -= damage;
            _healthBarController.SetHealth(_currentHp);

            if (_currentHp <= _minHp)
            {
                Destroy(gameObject);
                EventManager.SendEnemyDestroyed();
            }
        }
    }
}