using System;
using Assets.Scripts.Architecture.Services;
using UnityEngine;

namespace Assets.Scripts.Input
{
    public class SwipeDetector : ISwipeDetector
    {
        private readonly IInputService _inputService;

        public event Action OnSwipeUp;
        public event Action OnSwipeDown;
        public event Action OnSwipeLeft;
        public event Action OnSwipeRight;

        private Vector2 _startPosition;
        private float _startTime;

        private Vector2 _endPosition;
        private float _endTime;

        private float _minimumDistance = 0.1f;
        private float _maximumTime = 0.25f;

        private double _directionThreshold = 0.9f;

        public SwipeDetector(IInputService inputService)
        {
            _inputService = inputService;

            _inputService.OnTouchStarted += SwipeStart;
            _inputService.OnTouchEnded += SwipeEnd;
        }

        private void SwipeStart(Vector2 position, float time)
        {
            _startPosition = position;
            _startTime = time;
        }

        private void SwipeEnd(Vector2 position, float time)
        {
            _endPosition = position;
            _endTime = time;
            DetectSwipe();
        }

        private void DetectSwipe()
        {
            if (Vector3.Distance(_startPosition, _endPosition) >= _minimumDistance && (_endTime - _startTime) <= _maximumTime)
            {
                Vector3 direction = _endPosition - _startPosition;
                Vector3 direction2D = new Vector2(direction.x, direction.y).normalized;

                SwipeDirection(direction2D);
            }
        }

        private void SwipeDirection(Vector2 direction)
        {
            if (Vector2.Dot(Vector2.up, direction) >= _directionThreshold)
                OnSwipeUp?.Invoke();
            else if (Vector2.Dot(Vector2.down, direction) >= _directionThreshold)
                OnSwipeDown?.Invoke();
            else if (Vector2.Dot(Vector2.left, direction) >= _directionThreshold)
                OnSwipeLeft?.Invoke();
            else if (Vector2.Dot(Vector2.right, direction) >= _directionThreshold)
                OnSwipeRight?.Invoke();
        }
    }
}