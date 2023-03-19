using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TowerCharacteristics : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentDamageText;
    [SerializeField] private TextMeshProUGUI _currentFireSpeedText;
    [SerializeField] private TextMeshProUGUI _currentAttackRangeText;

    [SerializeField] private double _damage = 25f;
    [SerializeField] private double _fireSpeed = 1f;
    [SerializeField] private double _attackRange = 10f;
    [SerializeField] private double _upgradePrice = 40;

    [SerializeField] private Canvas _towerCanvas;

    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _fireSpeedText;
    [SerializeField] private TextMeshProUGUI _attackRangeText;

    [SerializeField] private TextMeshProUGUI _upgradePriceText;

    [SerializeField] private Button _upgradeButton;

    [SerializeField] private Button _closeCanvasButton;

    [SerializeField] private Vector3 _canvasScale; 

    private float _damageIncreasing = 1.2f;
    private float _fireSpeedIncreasing = 1.2f;
    private float _attackRangeIncreasing = 1.05f;
    private float _priceIncreasing = 1.2f;

    private float _scaleDuration = 0.3f;

    private CoinSystem _coinSystem;

    private void Start()
    {
        _coinSystem = GameObject.FindGameObjectWithTag(Constants.CoinSystemTag.ToString()).GetComponent<CoinSystem>();
    }

    private void Awake()
    {
        UpdateCurrentCharacteristicsText();
        UpdateUpgradeText();

        EventManager.UpgradeTowerTextUpdate.AddListener(UpdateCurrentCharacteristicsText);
        EventManager.UpgradeTowerTextUpdate.AddListener(UpdateUpgradeText);

        _towerCanvas.worldCamera = Camera.main;

        _upgradeButton.onClick.AddListener(OnUpgradeButtonClickHandler);
        _closeCanvasButton.onClick.AddListener(OnCloseCanvasButtonClickHandler);          
    }

    private void Update()
    {
        _towerCanvas.gameObject.transform.LookAt(Camera.main.transform);
    }

    private void OnMouseDown()
    {
        OpenUpgradeCanvas();
    }

    private void OnUpgradeButtonClickHandler()
    {
        Upgrade();
    }

    private void OnCloseCanvasButtonClickHandler()
    {
        CloseUpgradeCanvas();
    }

    private void OpenUpgradeCanvas()
    {
        _towerCanvas.gameObject.SetActive(true);
        LeanTween.scale(_towerCanvas.gameObject, _canvasScale, _scaleDuration);
    }

    private void CloseUpgradeCanvas()
    {
        LeanTween.scale(_towerCanvas.gameObject, Vector3.zero, _scaleDuration).setOnComplete(OffUpgradeCanvas);      
    }
    
    private void OffUpgradeCanvas()
    {
        _towerCanvas.gameObject.SetActive(false);
    }

    private void UpdateUpgradeText()
    {
        _damageText.text = _damage.ToString() + $"<color=green> + {Math.Round(_damage * (_damageIncreasing - 1), 1)} </color>";
        _fireSpeedText.text = _fireSpeed.ToString() + $"<color=green> - {Math.Round(_fireSpeed * (_fireSpeedIncreasing - 1), 1)} </color>";
        _attackRangeText.text = _attackRange.ToString() + $"<color=green> + {Math.Round(_attackRange * (_attackRangeIncreasing - 1), 1)} </color>";
        _upgradePriceText.text = $"Cost {Math.Round(_upgradePrice, 1)}";
    }

    private void UpdateCurrentCharacteristicsText()
    {
        _currentDamageText.text = _damage.ToString();
        _currentFireSpeedText.text = _fireSpeed.ToString();
        _currentAttackRangeText.text = _attackRange.ToString();
    }

    private void Upgrade()
    {
        if (_coinSystem != null)
        {
            if (_coinSystem.Coins >= _upgradePrice)
            {
                _damage = Math.Round(_damage *= _damageIncreasing, 1);
                _fireSpeed = Math.Round(_fireSpeed *= _fireSpeedIncreasing, 1);
                _attackRange = Math.Round(_attackRange *= _attackRangeIncreasing, 1);

                _upgradePrice = Math.Round(_upgradePrice *= _priceIncreasing, 1);

                EventManager.SendTowerUpgraded((float)_upgradePrice);
                EventManager.SendUpgradeTowerTextUpdate();
            }
        }
    }
}
