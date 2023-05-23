using System;

namespace Assets.Scripts.Input
{
    public interface ISwipeDetector
    {
        event Action OnSwipeUp;
        event Action OnSwipeDown;
        event Action OnSwipeLeft; 
        event Action OnSwipeRight;
    }
}