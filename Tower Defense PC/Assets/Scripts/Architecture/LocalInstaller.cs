using Zenject;
using UnityEngine;

public class LocalInstaller : MonoInstaller
{
    public LevelSettinsHolder LevelSettinsHolder;
    public LocalCoinService LocalCoinService;
    public PlayerHealth PlayerHealth;
    public UIInteraction UIInteraction;
    public Finish Finish;

    public override void InstallBindings()
    {
        BindLevelSettinsHolder();
        BindLocalCoinService();
        BindPlayerHealth();
        BindUIInteraction();
        BindFinish();    
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

    private void BindPlayerHealth()
    {
        PlayerHealth playerHealth = Container
            .InstantiatePrefabForComponent<PlayerHealth>(PlayerHealth, transform.position, Quaternion.identity, null);

        Container
            .Bind<PlayerHealth>()
            .FromInstance(playerHealth)
            .AsSingle();
    }

    private void BindUIInteraction()
    {
        Container
            .Bind<UIInteraction>()
            .FromInstance(UIInteraction)
            .AsSingle();
    }

    private void BindFinish()
    {      
        Container
            .Bind<Finish>()
            .FromInstance(Finish)
            .AsSingle();
    }
}
