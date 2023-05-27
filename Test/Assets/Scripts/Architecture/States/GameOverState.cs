using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Data;
using Assets.Scripts.UI;
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
            mainFactory.CreateBaseComponent<GameOverView>(AssetPath.GameOverView);
            mainFactory.Car.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}