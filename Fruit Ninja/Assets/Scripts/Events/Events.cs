using UnityEngine.Events;

public class Events
{
    public static UnityEvent OnFruitSliced = new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();

    public static void SendOnFruitSliced()
    {
        OnFruitSliced.Invoke();
    }

    public static void SendOnGameOver() 
    { 
        OnGameOver.Invoke();
    }
}
