using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TowerCharacteristics : MonoBehaviour
{
    public float Damage = 25f;
    public float FireSpeed = 1f;
    public float AttackRange = 10f;
    public float UpgradePrice = 40f;

    [SerializeField] private TextMeshProUGUI _currentDamageText;
    [SerializeField] private TextMeshProUGUI _currentFireSpeedText;
    [SerializeField] private TextMeshProUGUI _currentAttackRangeText;

    [SerializeField] private Canvas _towerCanvas;

    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _fireSpeedText;
    [SerializeField] private TextMeshProUGUI _attackRangeText;

    [SerializeField] private TextMeshProUGUI _upgradePriceText;

    [SerializeField] private Button _upgradeButton;

    [SerializeField] private Vector3 _canvasScale; 

    private float _damageIncreasing = 1.2f;
    private float _fireSpeedIncreasing = 0.05f;
    private float _attackRangeIncreasing = 1.05f;
    private float _priceIncreasing = 1.2f;

    private float _canvasScaleDuration = 0.3f;

    private CoinSystem _coinSystem;

    private bool _isUpgrageCanvasOpened = false;

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
    }

    private void Update()
    {
        _towerCanvas.gameObject.transform.LookAt(Camera.main.transform);
    }

    private void OnMouseDown()
    {
        if (_isUpgrageCanvasOpened == false)
        {
            _isUpgrageCanvasOpened = true;
            OpenUpgradeCanvas();
        }
        else
        {
            _isUpgrageCanvasOpened = false;
            CloseUpgradeCanvas();
        }
    }

    private void OnUpgradeButtonClickHandler()
    {
        AudioManager.Instance.PlaySfx(SfxType.UIClick);
        Upgrade();
    }

    private void OpenUpgradeCanvas()
    {
        _towerCanvas.gameObject.SetActive(true);
        LeanTween.scale(_towerCanvas.gameObject, _canvasScale, _canvasScaleDuration);
    }

    private void CloseUpgradeCanvas()
    {
        LeanTween.scale(_towerCanvas.gameObject, Vector3.zero, _canvasScaleDuration).setOnComplete(OffUpgradeCanvas);      
    }
    
    private void OffUpgradeCanvas()
    {
        _towerCanvas.gameObject.SetActive(false);
    }

    private void UpdateUpgradeText()
    {
        _damageText.text = Damage.ToString() + $"<color=green> + {Math.Round(Damage * (_damageIncreasing - 1), 1)} </color>";
        _fireSpeedText.text = FireSpeed.ToString() + $"<color=green> + {_fireSpeedIncreasing} </color>";
        _attackRangeText.text = AttackRange.ToString() + $"<color=green> + {Math.Round(AttackRange * (_attackRangeIncreasing - 1), 1)} </color>";
        _upgradePriceText.text = $"Cost {Math.Round(UpgradePrice, 1)}";
    }

    private void UpdateCurrentCharacteristicsText()
    {
        _currentDamageText.text = Damage.ToString();
        _currentFireSpeedText.text = FireSpeed.ToString();
        _currentAttackRangeText.text = AttackRange.ToString();
    }

    private void Upgrade()
    {
        if (_coinSystem != null)
        {
            if (_coinSystem.Coins >= UpgradePrice)
            {
                EventManager.SendTowerUpgraded(UpgradePrice);              

                Damage = (float)Math.Round(Damage *= _damageIncreasing, 1);
                FireSpeed += _fireSpeedIncreasing;
                AttackRange = (float)Math.Round(AttackRange *= _attackRangeIncreasing, 1);
                UpgradePrice = (float)Math.Round(UpgradePrice *= _priceIncreasing, 1);

                EventManager.SendUpgradeTowerTextUpdate();
            }
        }
    }
}
