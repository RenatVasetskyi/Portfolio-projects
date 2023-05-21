using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Tower.Characteristics
{
    public class UpgradeTowerWindowView : MonoBehaviour
    {
        public RectTransform Window;
        public CanvasScaler WindowCanvasScaler;

        public Button UpgradeButton;
        public Button CloseWindow;

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
            Window.transform.position = position;
            ControlWindowInFrames();
            LeanTween.scale(Window, Vector2.one, _windowScaleDuration);
        }

        public void Hide(out bool isOpened)
        {
            isOpened = false;
            LeanTween.scale(Window, Vector3.zero, _windowScaleDuration)
                .setOnComplete(() => Destroy(gameObject));
        }

        private void OnDestroy() =>
            TowerCharacteristics.OnTowerCharacteristicsUpgraded -= UpdateCharacteristics;

        private void ControlWindowInFrames()
        {
            float offset;

            if (Window.transform.localPosition.y - (Window.rect.height / 2) <= GetFramePosition(Screen.height, -2))
            {
                offset = GetFramePosition(Screen.height, -2) + (Window.rect.height / 2) - Window.transform.localPosition.y;
                Window.transform.localPosition = new Vector2(Window.transform.localPosition.x, Window.transform.localPosition.y + Math.Abs(offset));
            }

            if (Window.transform.localPosition.y + (Window.rect.height / 2) >= GetFramePosition(Screen.height, 2))
            {
                offset = GetFramePosition(Screen.height, 2) - (Window.rect.height / 2) - Window.transform.localPosition.y;
                Window.transform.localPosition = new Vector2(Window.transform.localPosition.x, Window.transform.localPosition.y - Math.Abs(offset));
            }

            if (Window.transform.localPosition.x - (Window.rect.width / 2) <= GetFramePosition(Screen.width, -2))
            {
                offset = GetFramePosition(Screen.width, -2) + (Window.rect.width / 2) - Window.transform.localPosition.x;
                Window.transform.localPosition = new Vector2(Window.transform.localPosition.x + Math.Abs(offset), Window.transform.localPosition.y);
            }

            if (Window.transform.localPosition.x + (Window.rect.width / 2) >= GetFramePosition(Screen.width, 2))
            {
                offset = GetFramePosition(Screen.width, 2) - (Window.rect.width / 2) - Window.transform.localPosition.x;
                Window.transform.localPosition = new Vector2(Window.transform.localPosition.x - Math.Abs(offset), Window.transform.localPosition.y);
            }
        }

        private float GetFramePosition(float size, float valueToDevide) =>
            size / valueToDevide;
    }
}