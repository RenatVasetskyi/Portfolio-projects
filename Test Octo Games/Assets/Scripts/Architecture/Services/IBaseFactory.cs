using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    public interface IBaseFactory
    {
        PlayerHealth Player { get; }
        Transform CreateBaseObjectWithObject(string path);
        T CreateBaseObjectWithContainer<T>(string path, Transform parent) where T : Component;
        void CreatePlayer();
    }
}