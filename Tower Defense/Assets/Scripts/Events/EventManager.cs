using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent<bool> LevelPassed = new UnityEvent<bool>();  
    public static UnityEvent EnemySpawned = new UnityEvent();
    public static UnityEvent EnemyDestroyed = new UnityEvent();
    public static UnityEvent<float> HpChanged = new UnityEvent<float>();

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

    public static void SendHpChanged(float damage)
    {
        HpChanged.Invoke(damage);
    }
}
