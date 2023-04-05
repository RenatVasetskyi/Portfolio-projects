using Zenject;

public class LocalCoinService
{
    public int Coins { get; set; }

    [Inject]
    public LocalCoinService(LevelSettinsHolder levelSettinsHolder)
    {       
        Coins = levelSettinsHolder.Coins;
    }
}
