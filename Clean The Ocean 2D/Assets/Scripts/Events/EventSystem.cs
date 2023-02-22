using UnityEngine.Events;

public class EventSystem
{
    public static UnityEvent OnBottleTaken = new UnityEvent();

    public static void SendBottleTaken()
    {
        OnBottleTaken.Invoke();
    }
}
