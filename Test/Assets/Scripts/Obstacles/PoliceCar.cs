using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.States;
using Assets.Scripts.Car;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    public class PoliceCar : MonoBehaviour
    {
        public float LifeTime;

        private Transform _target;
        private float _speed;
        private float _deceleration = 250f;

        private void Awake()
        {
            _target = AllServices.Container.Single<IMainFactory>().Car;
            _speed = _target.GetComponent<CarMovement>().MaxSpeed / _deceleration;
        }

        private void Update() =>
            Move();

        private void Move() =>
            transform.position += _target.position * _speed * Time.deltaTime;

        private void OnTriggerEnter2D() =>
            AllServices.Container.Single<IStateMachine>().Enter<GameOverState>();
    }
}