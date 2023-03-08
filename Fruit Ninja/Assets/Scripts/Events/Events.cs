using UnityEngine.Events;

public class Events
{
    public static UnityEvent OnFruitSliced = new UnityEvent();
    public static UnityEvent OnBombExploded = new UnityEvent();
    public static UnityEvent OnGameStarted = new UnityEvent();

    public static void SendOnFruitSliced()
    {
        OnFruitSliced.Invoke();
    }

    public static void SendOnBombExploded() 
    {
        OnBombExploded.Invoke();
    }

    public static void SendOnGameStarted()
    {
        OnGameStarted.Invoke();
    }
}
