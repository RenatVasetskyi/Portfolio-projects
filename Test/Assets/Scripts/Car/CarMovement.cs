using Assets.Scripts.Car.UI;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Car
{
    public class CarMovement : MonoBehaviour
    {
        [SerializeField] private CarControlView _carControlView;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private CarModel _car;
        [SerializeField] private StartGame _startGame;

        private void Awake()
        {
            _rigidbody.isKinematic = true;
            _startGame.OnGameStarted += () => _rigidbody.isKinematic = false;
        }

        private void Update()
        {
            if (_carControlView.GasPedal.IsPressed)
                AddForce(_rigidbody, Vector2.up, _car.ForwardSpeed);
            else if (_carControlView.BrakePedal.IsPressed)
                AddForce(_rigidbody, Vector2.down, _car.BrakingSpeed);

            if (_carControlView.LeftArrow.IsPressed)
                AddForce(_rigidbody, Vector2.left, _car.TurningSpeed);
            else if (_carControlView.RightArrow.IsPressed)
                AddForce(_rigidbody, Vector2.right, _car.TurningSpeed);
        }

        private void AddForce(Rigidbody2D rigidbody, Vector2 direction, float speed) =>
            rigidbody.AddForce(direction * speed * Time.deltaTime);
    }
}