public class GoblinHealthController : VitalitySystem
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

    public GoblinHealthController()
    {
        _maxHp = 80;
        _minHp = 0;
        _currentHp = _maxHp;
    }
}
