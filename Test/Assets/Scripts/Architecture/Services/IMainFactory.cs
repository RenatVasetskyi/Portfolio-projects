using Assets.Scripts.Car.UI;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    public interface IMainFactory : IService
    {
        StartGame StartGameView { get; }
        CarControlView CarControlView { get; }
        Transform Car { get; }
        void CreateCar(Vector2 at);
        void CreateCarControlView();
        void CreateStartGameView();
        void CreateBaseComponent<T>(string path) where T : Component;
        void CreateBaseComponent<T>(string path, Transform parent) where T : Component;
        Transform CreateUIRoot();
    }
}