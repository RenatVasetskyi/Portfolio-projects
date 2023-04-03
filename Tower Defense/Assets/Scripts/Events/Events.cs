using UnityEngine.Events;

namespace MyEvents
{
    public class Events
    {
        public static UnityEvent OnGameStarted = new UnityEvent();
        public static UnityEvent OnGameOver = new UnityEvent();      
        public static UnityEvent OnEnemyKilled = new UnityEvent();
        public static UnityEvent<float> OnEnemyHpChanged = new UnityEvent<float>();
        public static UnityEvent<int> OnPlayerHpChanged = new UnityEvent<int>();
        public static UnityEvent<int> OnBoughtTower = new UnityEvent<int>();
        public static UnityEvent<float> OnTowerUpgraded = new UnityEvent<float>();
        public static UnityEvent OnUpgradeTowerTextUpdated = new UnityEvent();
        public static UnityEvent OnNotEnoughMoney = new UnityEvent();
        public static UnityEvent OnTowerShot = new UnityEvent();
        public static UnityEvent OnGotCoins = new UnityEvent();

        public static void SendGameStarted()
        {
            OnGameStarted.Invoke();
        }

        public static void SendGameOver()
        {
            OnGameOver.Invoke();
        }     

        public static void SendEnemyKilled()
        {
            OnEnemyKilled.Invoke();
        }

        public static void SendEnemyHpChanged(float damage)
        {
            OnEnemyHpChanged.Invoke(damage);
        }

        public static void SendPlayerHpChanged(int damage)
        {
            OnPlayerHpChanged.Invoke(damage);
        }    

        public static void SendBoughtTower(int price)
        {
            OnBoughtTower.Invoke(price);
        }

        public static void SendTowerUpgraded(float price)
        {
            OnTowerUpgraded.Invoke(price);
        }

        public static void SendUpgradeTowerTextUpdate()
        {
            OnUpgradeTowerTextUpdated.Invoke();
        }

        public static void SendNotEnoughMoney()
        {
            OnNotEnoughMoney.Invoke();
        }

        public static void SendTowerShot()
        {
            OnTowerShot.Invoke();
        }

        public static void SendGetCoins()
        {
            OnGotCoins.Invoke();
        }
    }
}
