using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent GameStarted = new UnityEvent();
    public static UnityEvent GameOver = new UnityEvent();
    public static UnityEvent<bool> LevelPassed = new UnityEvent<bool>();  
    public static UnityEvent EnemySpawned = new UnityEvent();
    public static UnityEvent EnemyDestroyed = new UnityEvent();
    public static UnityEvent<float> EnemyHpChanged = new UnityEvent<float>();
    public static UnityEvent<int> PlayerHpChanged = new UnityEvent<int>();

    public static void SendGameStarted()
    {
        GameStarted.Invoke();
    }

    public static void SendGameOver()
    {
        GameOver.Invoke();
    }

    public static void SendLevelPassed(bool passed)
    {
        LevelPassed.Invoke(passed);
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
}
