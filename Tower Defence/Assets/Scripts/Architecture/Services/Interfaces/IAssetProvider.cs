using Object = UnityEngine.Object;

namespace Assets.Scripts.Architecture.Services.Interfaces
{
    public interface IAssetProvider
    {
        T Initialize<T>(string path) where T : Object;
    }
}