using UnityEngine;

public class UpgradeTower : TowerCharacteristics
{
    protected float _upgradePrice = 40;  

    protected float _damageIncreasing = 1.2f;
    protected float _fireSpeedIncreasing = 1.2f;
    protected float _attackRangeIncreasing = 1.05f;

    private CoinSystem _coinSystem;

    private float _priceIncreasing = 1.2f; 

    private void Start()
    {
        _coinSystem = GameObject.FindGameObjectWithTag(Constants.CoinSystemTag.ToString()).GetComponent<CoinSystem>();
    }

    protected void Upgrade()
    {
        if (_coinSystem != null)
        {
            if (_coinSystem.Coins >= _upgradePrice)
            {             
                Mathf.Round(_damage *= _damageIncreasing);
                Mathf.Round(_fireSpeed *= _fireSpeedIncreasing);
                Mathf.Round(_attackRange *= _attackRangeIncreasing);

                Mathf.Round(_upgradePrice *= _priceIncreasing);

                EventManager.SendTowerUpgraded(_upgradePrice);
                EventManager.SendUpgradeTowerTextUpdate();
            }
        }
    }
}
