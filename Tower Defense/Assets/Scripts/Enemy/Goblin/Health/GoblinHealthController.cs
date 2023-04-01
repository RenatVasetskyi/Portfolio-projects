public class GoblinHealthController : VitalitySystem
{
    public GoblinHealthController()
    {
        _maxHp = 80;
        _minHp = 0;
        _currentHp = _maxHp;
    }

    private void Awake()
    {
        EventManager.EnemyHpChanged.AddListener(TakeDamage);
        _healthBarController.SetMaxHealth(_maxHp);
    }
}
