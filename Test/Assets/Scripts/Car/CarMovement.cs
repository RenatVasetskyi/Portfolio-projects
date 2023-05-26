using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Car.UI;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Car
{
    public class CarMovement : MonoBehaviour
    {
        public float MaxSpeed;

        [SerializeField] private Rigidbody2D _rigidbody;

        [SerializeField] private float _forwardForce;
        [SerializeField] private float _turningForce;
        [SerializeField] private float _brakingForce;
        
        private CarControlView _carControlView;
        private StartGame _startGame;

        private IMainFactory _mainFactory;

        private void Awake()
        {
            _mainFactory = AllServices.Container.Single<IMainFactory>();
            _startGame = _mainFactory.StartGameView;
            _carControlView = _mainFactory.CarControlView;

            _rigidbody.isKinematic = true;
            _startGame.OnGameStarted += () => _rigidbody.isKinematic = false;
        }

        private void Update()
        {
            if (_carControlView.GasPedal.IsPressed)
                AddForce(_rigidbody, Vector2.up, _forwardForce);
            else if (_carControlView.BrakePedal.IsPressed)
                AddForce(_rigidbody, Vector2.down, _forwardForce);

            if (_carControlView.LeftArrow.IsPressed)
                AddForce(_rigidbody, Vector2.left, _turningForce);
            else if (_carControlView.RightArrow.IsPressed)
                AddForce(_rigidbody, Vector2.right, _turningForce);

            ClampSpeed();
        }

        private void ClampSpeed()
        {
            if (_rigidbody.velocity.y > MaxSpeed)
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, MaxSpeed);
        }

        private void AddForce(Rigidbody2D rigidbody, Vector2 direction, float force) =>
            rigidbody.AddForce(direction * force * Time.deltaTime);
    }
}