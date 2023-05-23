using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Input;
using Assets.Scripts.Player.Animations;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private float _forwardSpeed;
        [SerializeField] private float _forwardSpeedIncreasing;

        [SerializeField] private float _jumpForce;

        private ISwipeDetector _swipeDetector;
        private IInputService _inputService;

        [Inject]
        public void Construct(ISwipeDetector swipeDetector, IInputService inputService)
        {
            _swipeDetector = swipeDetector;
            _inputService = inputService;
        }

        private void Awake()
        {
            _inputService.SetCurrentCamera(UnityEngine.Camera.main);
            _swipeDetector.OnSwipeUp += Jump;
        }

        private void OnDisable() =>
            _swipeDetector.OnSwipeUp -= Jump;

        private void FixedUpdate() =>
            MoveForward();

        private void MoveForward()
        {
            _rigidbody.velocity += new Vector3(0, Physics.gravity.y, _forwardSpeed);
            _forwardSpeed *= _forwardSpeedIncreasing;
        }

        private void Jump() =>
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}