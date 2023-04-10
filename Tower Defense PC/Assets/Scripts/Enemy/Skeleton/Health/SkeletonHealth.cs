public class SkeletonHealth : VitalitySystem
{
    public SkeletonHealth()
    {
        _maxHp = 140;
        _minHp = 0;
        _currentHp = _maxHp;
    }

    private void Awake()
    {
        _enemyHealthBar.Initialize(_maxHp);
    }
}
