using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonHealthController : VitalitySystem
{   
    public SkeletonHealthController()
    {
        _maxHp = 100;
        _minHp = 0;
        _currentHp = _maxHp;       
    }

    private void Start()
    {
        _healthBarController.SetMaxHealth(_maxHp);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.SendHpChanged(50);
        }
    }

    private void Awake()
    {
        EventManager.HpChanged.AddListener(TakeDamage);
    }

    protected override void TakeDamage(float damage)
    {
        _currentHp = _maxHp - damage;
        _healthBarController.SetHealth(_currentHp);
    }
}
