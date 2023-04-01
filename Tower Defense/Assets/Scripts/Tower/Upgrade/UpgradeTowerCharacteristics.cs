using UnityEngine;
using System;
using UnityEngine.UI;

public class UpgradeTowerCharacteristics : MonoBehaviour, IUpgaradeTower, IInitialize
{
    public float Damage { get; private set; }
    public float FireSpeed { get; private set; }
    public float AttackRange { get; private set; }
    public float UpgradePrice { get; private set; }

    public float DamageIncreasing { get; private set; } = 1.2f;
    public float FireSpeedIncreasing { get; private set; } = 0.2f;
    public float AttackRangeIncreasing { get; private set; } = 1.1f;
    public float PriceIncreasing { get; private set; } = 1.2f;

    [SerializeField] private TowerSelectionButton _towerSelectionButton;

    [SerializeField] private Button _upgradeButton;

    private CoinSystem _coinSystem;

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

                Damage = (float)Math.Round(Damage *= DamageIncreasing, 1);
                FireSpeed += FireSpeedIncreasing;
                AttackRange = (float)Math.Round(AttackRange *= AttackRangeIncreasing, 1);
                UpgradePrice = (float)Math.Round(UpgradePrice *= PriceIncreasing, 1);

                EventManager.SendUpgradeTowerTextUpdate();
            }
        }
    }

    private void Awake()
    {
        Initialize();

        _upgradeButton.onClick.AddListener(OnUpgradeButtonClickHandler);
    }

    private void Start()
    {
        _coinSystem = GameObject.FindGameObjectWithTag(Constants.CoinSystemTag.ToString()).GetComponent<CoinSystem>();
    }

    private void OnUpgradeButtonClickHandler()
    {
        AudioManager.Instance.PlaySfx(SfxType.UIClick);
        Upgrade();
    }
}
