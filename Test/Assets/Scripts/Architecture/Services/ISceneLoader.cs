using System;

namespace Assets.Scripts.Architecture.Services
{
    public interface ISceneLoader : IService
    {
        void Load(string nextScene, Action onLoaded = null);
    }
}