using UnityEngine;

public class VitalitySystem : MonoBehaviour
{
    [SerializeField] protected HealthBarController _healthBarController;

    [SerializeField] protected float _maxHp;
    [SerializeField] protected float _currentHp;
    [SerializeField] protected float _minHp;

    protected virtual void TakeDamage(float damage)
    {
        _currentHp = _maxHp - damage;
        _healthBarController.SetHealth(_currentHp);       
    }
}