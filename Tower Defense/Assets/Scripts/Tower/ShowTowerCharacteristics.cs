using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ShowTowerCharacteristics : MonoBehaviour, IUpgaradeTower, IUpgradeCanvas, IInitialize
{
    public float Damage { get; private set; }
    public float FireSpeed { get; private set; }
    public float AttackRange { get; private set; }
    public float UpgradePrice { get; private set; }

    [SerializeField] private TowerSelectionButton _towerSelectionButton;

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
    private float _fireSpeedIncreasing = 0.2f;
    private float _attackRangeIncreasing = 1.1f;
    private float _priceIncreasing = 1.2f;

    private float _canvasScaleDuration = 0.3f;

    private CoinSystem _coinSystem;

    private bool _isUpgrageCanvasOpen = false;

    public void Initialize()
    {
        Damage = _towerSelectionButton.Damage;
        FireSpeed = _towerSelectionButton.FireSpeed;
        AttackRange = _towerSelectionButton.AttackRange;
        UpgradePrice = _towerSelectionButton.UpgradePrice;
    }

    public void Upgrade()
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

    public void UpdateUpgradeText()
    {
        _damageText.text = Damage.ToString() + $"<color=green> + {Math.Round(Damage * (_damageIncreasing - 1), 1)} </color>";
        _fireSpeedText.text = FireSpeed.ToString() + $"<color=green> + {_fireSpeedIncreasing} </color>";
        _attackRangeText.text = AttackRange.ToString() + $"<color=green> + {Math.Round(AttackRange * (_attackRangeIncreasing - 1), 1)} </color>";
        _upgradePriceText.text = $"Cost {Math.Round(UpgradePrice, 1)}";
    }

    public void UpdateCurrentCharacteristicsText()
    {
        _currentDamageText.text = Damage.ToString();
        _currentFireSpeedText.text = FireSpeed.ToString();
        _currentAttackRangeText.text = AttackRange.ToString();
    }

    public void OpenUpgradeCanvas()
    {
        _towerCanvas.gameObject.SetActive(true);
        LeanTween.scale(_towerCanvas.gameObject, _canvasScale, _canvasScaleDuration);
    }

    public void CloseUpgradeCanvas()
    {
        LeanTween.scale(_towerCanvas.gameObject, Vector3.zero, _canvasScaleDuration).setOnComplete(OffUpgradeCanvas);
    }

    public void OffUpgradeCanvas()
    {
        _towerCanvas.gameObject.SetActive(false);
    }

    private void Awake()
    {
        Initialize();

        UpdateCurrentCharacteristicsText();
        UpdateUpgradeText();

        _towerCanvas.worldCamera = Camera.main;

        _upgradeButton.onClick.AddListener(OnUpgradeButtonClickHandler);
    }

    private void Start()
    {
        _coinSystem = GameObject.FindGameObjectWithTag(Constants.CoinSystemTag.ToString()).GetComponent<CoinSystem>();      
    }

    private void Update()
    {
        _towerCanvas.gameObject.transform.LookAt(Camera.main.transform);
    }

    private void OnMouseDown()
    {
        if (_isUpgrageCanvasOpen == false)
        {
            _isUpgrageCanvasOpen = true;
            OpenUpgradeCanvas();
        }
        else
        {
            _isUpgrageCanvasOpen = false;
            CloseUpgradeCanvas();
        }
    }

    private void OnUpgradeButtonClickHandler()
    {
        AudioManager.Instance.PlaySfx(SfxType.UIClick);       
        Upgrade();
    }
}
