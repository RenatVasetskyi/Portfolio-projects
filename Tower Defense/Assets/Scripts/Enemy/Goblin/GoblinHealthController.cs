public class GoblinHealthController : VitalitySystem
{
    private void Awake()
    {
        EventManager.EnemyHpChanged.AddListener(TakeDamage);
        _healthBarController.SetMaxHealth(_maxHp);
    }

    //public override void TakeDamage(float damage)
    //{
    //    _currentHp -= damage;
    //    _healthBarController.SetHealth(_currentHp);

    //    if (_currentHp <= _minHp)
    //        Destroy(gameObject);
    //}

    public GoblinHealthController()
    {
        _maxHp = 80;
        _minHp = 0;
        _currentHp = _maxHp;
    }
}
