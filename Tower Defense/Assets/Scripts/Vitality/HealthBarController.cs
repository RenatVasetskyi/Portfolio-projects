using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider _slider;
    [SerializeField] private UnityEngine.UI.Image _fill;
    [SerializeField] private Gradient _gradient;

    [SerializeField] private Transform _camera;

    public void SetMaxHealth(float health)
    {
        _slider.maxValue = health;
        _slider.value = health;

        _gradient.Evaluate(1f);
        _fill.color = _gradient.Evaluate(1f);
    }  

    public void SetHealth(float health)
    {
        _slider.value = health;

        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }

    private void LateUpdate()
    {
        transform.LookAt(_camera);
    }
}
