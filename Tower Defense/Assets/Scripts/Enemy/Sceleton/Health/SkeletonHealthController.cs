public class SkeletonHealthController : VitalitySystem
{     
    private void Awake()
    {
        EventManager.EnemyHpChanged.AddListener(TakeDamage);
        _healthBarController.SetMaxHealth(_maxHp);
    }

    public SkeletonHealthController()
    {
        _maxHp = 100;
        _minHp = 0;
        _currentHp = _maxHp;
    }
}
