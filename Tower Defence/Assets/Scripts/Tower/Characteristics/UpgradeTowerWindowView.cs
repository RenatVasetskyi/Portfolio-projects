using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Tower.Characteristics
{
    public class UpgradeTowerWindowView : MonoBehaviour
    {
        public Button UpgradeButton;
        public Button CloseWindow;

        [SerializeField] private Vector2 _upgradeWindowOffset;

        [SerializeField] private TextMeshProUGUI _damageCountText;
        [SerializeField] private TextMeshProUGUI _fireSpeedCountText;
        [SerializeField] private TextMeshProUGUI _attackRangeCountText;
        [SerializeField] private TextMeshProUGUI _upgradePriceText; 

        [SerializeField] private float _windowScaleDuration;

        public TowerCharacteristics TowerCharacteristics { get; set; }

        public void UpdateCharacteristics()
        {
            _damageCountText.text = $"{TowerCharacteristics.Damage} +" +
                                    $" <color=green>{(TowerCharacteristics.Damage + TowerCharacteristics.DamageIncreasing) - TowerCharacteristics.Damage}</color=green>";
            _fireSpeedCountText.text = $"{TowerCharacteristics.FireSpeed} +" +
                                       $" <color=green>{(TowerCharacteristics.FireSpeed + TowerCharacteristics.FireSpeedIncreasing) - TowerCharacteristics.FireSpeed}</color=green>";
            _attackRangeCountText.text = $"{TowerCharacteristics.AttackRange} +" +
                                         $" <color=green>{(TowerCharacteristics.AttackRange + TowerCharacteristics.AttackRangeIncreasing) - TowerCharacteristics.AttackRange}</color=green>";
            _upgradePriceText.text = $"{TowerCharacteristics.UpgradePrice}";
        }

        public void Show(out bool IsOpened,Vector2 position)
        {
            IsOpened = true;
            gameObject.transform.position = position + _upgradeWindowOffset;
            LeanTween.scale(gameObject, Vector2.one, _windowScaleDuration);
        }

        public void Hide(out bool isOpened)
        {
            isOpened = false;
            LeanTween.scale(gameObject, Vector3.zero, _windowScaleDuration)
                .setOnComplete(() => Destroy(gameObject));
        }

        private void OnDestroy() =>
            TowerCharacteristics.OnTowerCharacteristicsUpgraded -= UpdateCharacteristics;
    }
}