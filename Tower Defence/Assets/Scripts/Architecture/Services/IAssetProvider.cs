using Object = UnityEngine.Object;

namespace Assets.Scripts.Architecture.Services
{
    public interface IAssetProvider
    {
        T Initialize<T>(string path) where T : Object;
    }
}