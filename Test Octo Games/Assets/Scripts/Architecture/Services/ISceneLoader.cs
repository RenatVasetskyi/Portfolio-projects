using System;

namespace Assets.Scripts.Architecture.Services
{
    public interface ISceneLoader
    {
        void Load(string nextScene, Action onLoaded = null);
    }
}