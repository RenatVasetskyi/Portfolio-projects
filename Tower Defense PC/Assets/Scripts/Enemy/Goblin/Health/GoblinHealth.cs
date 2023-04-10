public class GoblinHealth : VitalitySystem
{   
    public GoblinHealth()
    {
        _maxHp = 80;
        _minHp = 0;
        _currentHp = _maxHp;
    }

    private void Awake()
    {
        _enemyHealthBar.Initialize(_maxHp);    
    }
}
