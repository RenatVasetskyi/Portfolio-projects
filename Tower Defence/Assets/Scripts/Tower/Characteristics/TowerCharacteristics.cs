using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data.Levels;
using Assets.Scripts.Tower.Selection;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Tower.Characteristics
{
    public class TowerCharacteristics : MonoBehaviour
    {
        [SerializeField] AllLevelsSettings _levelsSettings; 
        [SerializeField] private TowerType _towerType;

        private TowerInfo _tower;

        private ILocalCoinService _localCoinService;

        public int CannonRotateSpeed { get; private set; }
        public int Damage { get; private set; }
        public float FireSpeed { get; private set; }
        public int AttackRange { get; private set; }
        public int UpgradePrice { get; private set; }

        public int DamageIncreasing { get; private set; }
        public float FireSpeedIncreasing { get; private set; }
        public int AttackRangeIncreasing { get; private set; }
        public int PriceIncreasing { get; private set; }

        [Inject]
        public void Construct(ILocalCoinService localCoinService) => 
            _localCoinService = localCoinService;

        public void Upgrade()
        {
            if (_localCoinService.Coins >= UpgradePrice)
            {
                Damage += DamageIncreasing;
                FireSpeed += FireSpeedIncreasing;
                AttackRange += AttackRangeIncreasing;
                UpgradePrice += PriceIncreasing;
            }
        }

        private void Awake() =>
            Initialize();

        private void Initialize()
        {
            GetCurrentTowerSettings();

            CannonRotateSpeed = _tower.RotateSpeed;
            //Damage = _tower.Bullet.Damage;
            FireSpeed = _tower.FireSpeed;
            AttackRange = _tower.AttackRange;
            UpgradePrice = _tower.UpgradePrice;

            DamageIncreasing = Damage / 3;
            FireSpeedIncreasing = FireSpeed / 4f;
            AttackRangeIncreasing = AttackRange / 5;
            PriceIncreasing = UpgradePrice / 2;
        }

        private void GetCurrentTowerSettings()
        {
            foreach (LevelSettings level in _levelsSettings.Levels)
            {
                foreach (TowerSelectionButton button in level.TowerSelectionButtons.Buttons)
                {
                    if (button.Tower.TowerType == _towerType)
                        _tower = button.Tower;
                }
            }
        }
    }
}