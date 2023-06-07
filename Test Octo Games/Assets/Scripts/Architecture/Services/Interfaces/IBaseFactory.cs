using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services.Interfaces
{
    public interface IBaseFactory
    {
        PlayerHealth Player { get; }
        T CreateBaseObjectWithObject<T>(string path) where T : Component;
        T CreateBaseObjectWithContainer<T>(string path) where T : Component;
        T CreateBaseObjectWithContainer<T>(string path, Transform parent) where T : Component;
        void CreatePlayer();
    }
}