public class GoblinHealthController : VitalitySystem
{
    private void Awake()
    {
        EventManager.EnemyHpChanged.AddListener(TakeDamage);
        _healthBarController.SetMaxHealth(_maxHp);
    }

    public GoblinHealthController()
    {
        _maxHp = 80;
        _minHp = 0;
        _currentHp = _maxHp;
    }
}
