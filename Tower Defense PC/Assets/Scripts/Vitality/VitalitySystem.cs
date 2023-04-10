using UnityEngine;

public class VitalitySystem : MonoBehaviour
{   
    [SerializeField] protected EnemyHealthBar _enemyHealthBar;

    [SerializeField] protected int _maxHp;

    protected int _currentHp;
    protected int _minHp = 0;

    public void TakeDamage(int damage)
    {
        _currentHp -= damage;
        _enemyHealthBar.SetHealth(_currentHp);

        if (_currentHp <= _minHp)
        {
            Destroy(gameObject);           
        }
    }
}
