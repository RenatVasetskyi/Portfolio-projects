using UnityEngine.Events;

public class Events
{
    public static UnityEvent OnFruitSliced = new UnityEvent();
    public static UnityEvent OnBombExploded = new UnityEvent();
    public static UnityEvent OnGameStarted = new UnityEvent();
    public static UnityEvent OnGamePaused = new UnityEvent();
    public static UnityEvent OnGameUnPaused = new UnityEvent();
    public static UnityEvent OnMainMenuOpened = new UnityEvent();

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

    public static void SendOnGamePaused()
    {
        OnGamePaused.Invoke();
    }

    public static void SendOnGameUnPaused() 
    {
        OnGameUnPaused.Invoke();
    }

    public static void SendOnMainMenuOpened()
    {
        OnMainMenuOpened.Invoke();
    }
}
