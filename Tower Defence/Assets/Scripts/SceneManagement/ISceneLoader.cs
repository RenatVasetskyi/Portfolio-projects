using System;

namespace Assets.Scripts.SceneManagement
{
    public interface ISceneLoader
    {
        void Load(string nextScene, Action onLoaded = null);
    }
}