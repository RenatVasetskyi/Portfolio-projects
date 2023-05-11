using System;
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

        public void Show(out bool isOpened, Vector2 position)
        {
            isOpened = true;
            transform.position = position + _upgradeWindowOffset;
            ControlWindowInFrames();
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

        private void ControlWindowInFrames()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();

            if (transform.localPosition.y >= GetFramePosition(Screen.height, 2))
            {
                float offsetY = transform.localPosition.y - Math.Abs(GetFramePosition(Screen.height, -2));
                transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - offsetY - (rectTransform.rect.height / 2));
            }

            if (transform.localPosition.y <= GetFramePosition(Screen.height, -2))
            {
                float offsetY = transform.localPosition.y + Math.Abs(GetFramePosition(Screen.height, -2));
                transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - offsetY + (rectTransform.rect.height / 2));
            }

            if (transform.localPosition.x <= GetFramePosition(Screen.width, -2))
            {
                float offsetX = transform.localPosition.x + Math.Abs(GetFramePosition(Screen.width, -2));
                transform.localPosition = new Vector2(transform.localPosition.x - offsetX + (rectTransform.rect.width / 2), transform.localPosition.y);
            }

            if (transform.localPosition.x >= GetFramePosition(Screen.width, 2))
            {
                float offsetX = transform.localPosition.x - Math.Abs(GetFramePosition(Screen.width, 2));
                transform.localPosition = new Vector2(transform.localPosition.x - offsetX - (rectTransform.rect.width / 2), transform.localPosition.y);
            }
        }

        private float GetFramePosition(float size, float valueToDevide) =>
            size / valueToDevide;
    }
}