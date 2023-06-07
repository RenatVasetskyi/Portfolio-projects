using Assets.Scripts.Player;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    public interface IBaseFactory
    {
        PlayerHealth Player { get; }
        PistolHolder PistolHolder { get; }
        Transform CreateBaseObjectWithObject(string path);
        T CreateBaseObjectWithContainer<T>(string path, Transform parent) where T : Component;
        void CreatePlayer();
    }
}