using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    public interface IAssetProvider : IService
    { 
        T Initialize<T>(string path) where T : Object;
    }
}