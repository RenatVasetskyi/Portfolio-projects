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

        [Inject]
        public void Construct(ISwipeDetector swipeDetector) =>
            _swipeDetector = swipeDetector;

        private void Awake()
        {
            _swipeDetector.SetCurrentCamera(UnityEngine.Camera.main);
            _swipeDetector.OnSwipeUp += Jump;
        }

        private void FixedUpdate() =>
            MoveForward();

        private void MoveForward() =>
            _characterController.Move(Vector3.forward * _forwardSpeed * Time.deltaTime);

        private void Jump()
        {
            Debug.Log("Jump");
        }
    }
}