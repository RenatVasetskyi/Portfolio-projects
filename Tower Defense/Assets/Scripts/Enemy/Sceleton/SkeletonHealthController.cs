public class SkeletonHealthController : VitalitySystem
{     
    private void Awake()
    {
        EventManager.EnemyHpChanged.AddListener(TakeDamage);
        _healthBarController.SetMaxHealth(_maxHp);
    }

    protected override void TakeDamage(float damage)
    {
        _currentHp = _maxHp - damage;
        _healthBarController.SetHealth(_currentHp);
    }

    public SkeletonHealthController()
    {
        _maxHp = 100;
        _minHp = 0;
        _currentHp = _maxHp;
    }
}
