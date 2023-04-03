using UnityEngine;
using System;
using UnityEngine.UI;
using Coins;
using Audio;
using Data;
using Events;

namespace Tower
{
    public class UpgradeTowerCharacteristics : MonoBehaviour, IUpgaradeTower, IInitialize
    {
        [SerializeField] private TowerInfo _tower;

        [SerializeField] private Button _upgradeButton;

        private CoinOperations _coinOperations;

        public float Damage { get; private set; }
        public float FireSpeed { get; private set; }
        public float AttackRange { get; private set; }
        public float UpgradePrice { get; private set; }

        public float DamageIncreasing { get; private set; } = 1.2f;
        public float FireSpeedIncreasing { get; private set; } = 0.2f;
        public float AttackRangeIncreasing { get; private set; } = 1.1f;
        public float PriceIncreasing { get; private set; } = 1.2f;

        public void Initialize()
        {
            Damage = _tower.Damage;
            FireSpeed = _tower.FireSpeed;
            AttackRange = _tower.AttackRange;
            UpgradePrice = _tower.UpgradePrice;
        }

        public void Upgrade()
        {
            if (_coinOperations != null)
            {
                if (_coinOperations.Coins >= UpgradePrice)
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
            _coinOperations = GameObject.FindGameObjectWithTag(Constants.CoinSystemTag.ToString()).GetComponent<CoinOperations>();
        }

        private void OnUpgradeButtonClickHandler()
        {
            AudioManager.Instance.PlaySfx(SfxType.UIClick);
            Upgrade();
        }
    }
}