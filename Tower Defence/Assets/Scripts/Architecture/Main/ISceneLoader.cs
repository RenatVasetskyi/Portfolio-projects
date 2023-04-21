using System;

namespace Assets.Scripts.Architecture.Main
{
    public interface ISceneLoader
    {
        void Load(string nextScene, Action onLoaded = null);
    }
}