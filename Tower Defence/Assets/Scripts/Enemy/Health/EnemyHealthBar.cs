using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Enemy.Health
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Main.Enemy _enemy;
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _fill;
        [SerializeField] private Gradient _gradient;

        private void Awake()
        {
            Initialize();
            _enemyHealth.OnHealthChanged += UpdateHealthBar;
        }

        private void LateUpdate() =>
            transform.LookAt(UnityEngine.Camera.main.transform);

        private void Initialize()
        {
            _slider.maxValue = _enemy.EnemyData.MaxHp;

            _gradient.Evaluate(1f);

            _slider.value = _enemy.EnemyData.MaxHp;
            _fill.color = _gradient.Evaluate(_slider.normalizedValue);
        }

        private void UpdateHealthBar() =>
            _slider.value = _enemyHealth.CurrentHp;
    }
}