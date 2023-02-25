using UnityEngine.Events;

public class EventSystem
{
    public static UnityEvent OnBottleTaken = new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();

    public static void SendBottleTaken()
    {
        OnBottleTaken.Invoke();
    }   

    public static void SendGameOver() 
    {
        OnGameOver.Invoke();
    }
}
