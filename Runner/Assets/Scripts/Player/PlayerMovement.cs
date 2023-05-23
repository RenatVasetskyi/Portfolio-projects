using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Input;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _forwardSpeed;

        private ISwipeDetector _swipeDetector;
        private IInputService _inputService;

        [Inject]
        public void Construct(ISwipeDetector swipeDetector, IInputService inputService)
        {
            _swipeDetector = swipeDetector;
            _inputService = inputService;
        }

        private void OnEnable()
        {
            _inputService.SetCurrentCamera(UnityEngine.Camera.main);
            _swipeDetector.OnSwipeUp += Jump;
        }

        private void OnDisable() =>
            _swipeDetector.OnSwipeUp -= Jump;

        private void FixedUpdate() =>
            MoveForward();

        private void MoveForward() =>
            _characterController.Move(Vector3.forward * _forwardSpeed * Time.deltaTime);

        private void Jump()
        {
        }
    }
}