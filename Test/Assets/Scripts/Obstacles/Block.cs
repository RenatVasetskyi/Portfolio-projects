using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.States;
using Assets.Scripts.Car;
using UnityEngine;

namespace Assets.Scripts.Obstacles
{
    public class Block : Obstacle
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            GiveDamage(other.GetComponent<CarHealth>(), _damage);
            AllServices.Container.Single<IStateMachine>().Enter<GameOverState>();
        }
    }
}