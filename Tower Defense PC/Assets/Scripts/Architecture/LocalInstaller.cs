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
        LocalCoinService = new LocalCoinService(LevelSettinsHolder);

        Container
            .Bind<LocalCoinService>()
            .FromInstance(LocalCoinService)
            .AsSingle();
    }
}
