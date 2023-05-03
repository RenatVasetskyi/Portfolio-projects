using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Tower.Characteristics
{
    public class TowerCharacteristicsDisplayer : MonoBehaviour
    {
        [SerializeField] private TowerCharacteristics _towerCharacteristics;
        
        [SerializeField] private TextMeshProUGUI _damageCountText;
        [SerializeField] private TextMeshProUGUI _fireSpeedCountText;
        [SerializeField] private TextMeshProUGUI _attackRangeCountText;

        [SerializeField] private Canvas _towerCharacteristicsCanvas;
        [SerializeField] private GameObject _towerCharacteristicsWindow;
        [SerializeField] private TextMeshProUGUI _upgradePriceText;

        [SerializeField] private Vector3 _canvasScale;

        private float _windowScaleDuration = 0.3f;

        private bool _isUpgrageWindowOpened = false;

        public void CloseTowerCharacteristicsWindow() =>
            LeanTween.scale(_towerCharacteristicsWindow.gameObject, Vector3.zero, _windowScaleDuration).setOnComplete(OffTowerCharacteristicsCanvas);

        private void Awake()
        {
            UpdateCharacteristics();
            _towerCharacteristics.OnTowerCharacteristicsUpgraded += UpdateCharacteristics;
            _towerCharacteristicsCanvas.worldCamera = UnityEngine.Camera.main;
        }

        private void Update() =>
            _towerCharacteristicsCanvas.gameObject.transform.LookAt(UnityEngine.Camera.main.transform);

        private void OnMouseDown()
        {
            if (IsPointerOverUI())
                return;

            if (_isUpgrageWindowOpened == false)
            {
                _isUpgrageWindowOpened = true;
                OpenTowerCharacteristicsWindow();
            }
            else
            {
                _isUpgrageWindowOpened = false;
                CloseTowerCharacteristicsWindow();
            }
        }

        private void UpdateCharacteristics()
        {
            _damageCountText.text = $"{_towerCharacteristics.Damage} +" +
                                    $" <color=green>{(_towerCharacteristics.Damage + _towerCharacteristics.DamageIncreasing) - _towerCharacteristics.Damage}</color=green>";
            _fireSpeedCountText.text = $"{_towerCharacteristics.FireSpeed} +" +
                                       $" <color=green>{(_towerCharacteristics.FireSpeed + _towerCharacteristics.FireSpeedIncreasing) - _towerCharacteristics.FireSpeed}</color=green>";
            _attackRangeCountText.text = $"{_towerCharacteristics.AttackRange} +" +
                                         $" <color=green>{(_towerCharacteristics.AttackRange + _towerCharacteristics.AttackRangeIncreasing) - _towerCharacteristics.AttackRange}</color=green>";
            _upgradePriceText.text = $"{_towerCharacteristics.UpgradePrice}";
        }

        private void OpenTowerCharacteristicsWindow()
        {
            _towerCharacteristicsCanvas.gameObject.SetActive(true);
            LeanTween.scale(_towerCharacteristicsWindow.gameObject, _canvasScale, _windowScaleDuration);
        }

        private void OffTowerCharacteristicsCanvas() =>
            _towerCharacteristicsCanvas.gameObject.SetActive(false);

        private bool IsPointerOverUI()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return true;
            return false;
        }
    }
}