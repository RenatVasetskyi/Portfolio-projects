using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent GameStarted = new UnityEvent();
    public static UnityEvent GameOver = new UnityEvent();
    public static UnityEvent EnemySpawned = new UnityEvent();
    public static UnityEvent EnemyDestroyed = new UnityEvent();
    public static UnityEvent<float> EnemyHpChanged = new UnityEvent<float>();
    public static UnityEvent<int> PlayerHpChanged = new UnityEvent<int>();
    public static UnityEvent TowerSpawned = new UnityEvent();
    public static UnityEvent<int> BoughtTower = new UnityEvent<int>();
    public static UnityEvent<float> TowerUpgraded = new UnityEvent<float>();
    public static UnityEvent UpgradeTowerTextUpdate  = new UnityEvent();
    public static UnityEvent NotEnoughMoney = new UnityEvent();
    public static UnityEvent TowerShot = new UnityEvent();
    public static UnityEvent GetCoins = new UnityEvent();

    public static void SendGameStarted()
    {
        GameStarted.Invoke();
    }

    public static void SendGameOver()
    {
        GameOver.Invoke();
    }

    public static void SendEnemySpawned()
    {
        EnemySpawned.Invoke();
    }

    public static void SendEnemyDestroyed()
    {
        EnemyDestroyed.Invoke();
    }

    public static void SendEnemyHpChanged(float damage)
    {
        EnemyHpChanged.Invoke(damage);
    }

    public static void SendPlayerHpChanged(int damage)
    {
        PlayerHpChanged.Invoke(damage);
    }

    public static void SendTowerSpawned() 
    {
        TowerSpawned.Invoke();
    }

    public static void SendBoughtTower(int price)
    {
        BoughtTower.Invoke(price);
    }

    public static void SendTowerUpgraded(float price)
    {
        TowerUpgraded.Invoke(price);
    }

    public static void SendUpgradeTowerTextUpdate()
    {
        UpgradeTowerTextUpdate.Invoke();
    }

    public static void SendNotEnoughMoney()
    {
        NotEnoughMoney.Invoke();    
    }

    public static void SendTowerShot()
    {
        TowerShot.Invoke();
    }

    public static void SendGetCoins()
    {
        GetCoins.Invoke();
    }
}
