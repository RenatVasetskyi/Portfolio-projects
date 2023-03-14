using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fill;
    [SerializeField] private Gradient _gradient;

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
        transform.LookAt(Camera.main.transform);
    }
}
