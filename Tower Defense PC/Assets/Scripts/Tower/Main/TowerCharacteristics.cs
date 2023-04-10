using UnityEngine;
using Zenject;

public class TowerCharacteristics : MonoBehaviour, IUpgradeTower
{
    [SerializeField] private TowerInfo _tower;   

    private LocalCoinService _localCoinService;

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
    private void Construct(LocalCoinService localCoinService)
    {
        _localCoinService = localCoinService;      
    }

    public void Initialize()
    {
        CannonRotateSpeed = _tower.RotateSpeed;
        Damage = _tower.Damage;
        FireSpeed = _tower.FireSpeed;
        AttackRange = _tower.AttackRange;
        UpgradePrice = _tower.UpgradePrice;

        DamageIncreasing = Damage / 3;
        FireSpeedIncreasing = FireSpeed / 4f;
        AttackRangeIncreasing = AttackRange / 5;
        PriceIncreasing = UpgradePrice / 2;
    }
  
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

    private void Awake()
    {
        Initialize();
    }
}

