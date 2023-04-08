using UnityEngine;
using Zenject;

public class LocalCoinService : MonoBehaviour
{
    public int Coins { get; set; }

    [Inject]
    private void Construct(LevelSettinsHolder levelSettinsHolder)
    {
        Coins = levelSettinsHolder.Coins;
    }   
}
