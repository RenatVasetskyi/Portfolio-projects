using Assets.Scripts.Architecture.Services;
using UnityEngine;

namespace Assets.Scripts.Architecture.States
{
    public class GameOverState : IState
    {
        public void Exit()
        {
        }

        public void Enter()
        {
            IMainFactory mainFactory = AllServices.Container.Single<IMainFactory>();
            mainFactory.CreateGameOverView();
            mainFactory.Car.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}