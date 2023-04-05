using UnityEngine;
using Zenject;

public class LocalInstaller : MonoInstaller
{  
    public LevelSettinsHolder LevelSettinsHolder;
    public LocalCoinService LocalCoinService;
    
    public override void InstallBindings()
    {
        BindLevelSettinsHolder();
        BindLocalCoinService();
    }

    private void BindLevelSettinsHolder()
    {
        Container
            .Bind<LevelSettinsHolder>()
            .FromNewScriptableObject(LevelSettinsHolder)
            .AsSingle();
    }

    private void BindLocalCoinService()
    {
        LocalCoinService localCoinService = Container
            .InstantiatePrefabForComponent<LocalCoinService>(LocalCoinService, transform.position, Quaternion.identity, null);

        Container
            .Bind<LocalCoinService>()
            .FromInstance(localCoinService)
            .AsSingle();
    }
}
