using System.Collections;
using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Car.UI;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Car
{
    public class CarMovement : MonoBehaviour
    {
        public float MaxSpeed;
        public float ForwardForce;

        [SerializeField] private Rigidbody2D _rigidbody;
        
        [SerializeField] private float _turningForce;
        [SerializeField] private float _brakingForce;
        
        private CarControlView _carControlView;
        private StartGameView _startGame;

        public void ResetForces()
        {
            MaxSpeed = 0;
            ForwardForce = 0;
            _brakingForce = 0;
            _turningForce = 0;
        }

        public void StartBoost(float boost, float duration) =>
            StartCoroutine(Boost(boost, duration));

        private void Awake()
        {
            IMainFactory mainFactory = AllServices.Container.Single<IMainFactory>();

            _startGame = mainFactory.StartGameView;
            _carControlView = mainFactory.CarControlView;

            _rigidbody.isKinematic = true;
            _startGame.OnGameStarted += () => _rigidbody.isKinematic = false;
        }

        private void Update()
        {
            if (_carControlView.GasPedal.IsPressed)
                AddForce(_rigidbody, Vector2.up, ForwardForce);
            else if (_carControlView.BrakePedal.IsPressed)
                AddForce(_rigidbody, Vector2.down, ForwardForce);

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

        private IEnumerator Boost(float boost, float duration)
        {
            ForwardForce *= boost;
            MaxSpeed *= boost;
            yield return new WaitForSeconds(duration);
            ForwardForce /= boost;
            MaxSpeed /= boost;
        }
    }
}