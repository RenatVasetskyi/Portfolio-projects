using MyEvents;

namespace Vitality
{
    public class SkeletonHealthController : VitalitySystem
    {
        public SkeletonHealthController()
        {
            _maxHp = 100;
            _minHp = 0;
            _currentHp = _maxHp;
        }

        private void Awake()
        {
            Events.OnEnemyHpChanged.AddListener(TakeDamage);
            _healthBarController.SetMaxHealth(_maxHp);
        }
    }
}
