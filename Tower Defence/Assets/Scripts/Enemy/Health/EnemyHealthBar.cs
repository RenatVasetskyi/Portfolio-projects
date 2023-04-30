using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Enemy.Health
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _fill;
        [SerializeField] private Gradient _gradient;

        private void Awake() => 
            Init();

        private void LateUpdate() =>
            transform.LookAt(UnityEngine.Camera.main.transform);

        private void Init()
        {
            _slider.maxValue = _enemy.EnemyData.MaxHp;
            _slider.value = _enemy.EnemyData.MaxHp;

            _gradient.Evaluate(1f);
            _fill.color = _gradient.Evaluate(1f);

            _slider.value = _enemy.EnemyData.MaxHp;
            _fill.color = _gradient.Evaluate(_slider.normalizedValue);
        }
    }
}