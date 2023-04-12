using System;
using UnityEngine;
using Zenject;

public class LocalCoinService : MonoBehaviour
{
    public event Action OnCoinsChanged;

    public int Coins { get; private set; }

    [Inject]
    private void Construct(LevelSettinsHolder levelSettinsHolder)
    {
        Coins = levelSettinsHolder.Coins;
    }

    public void Buy(int price)
    {
        Coins -= price;
        OnCoinsChanged?.Invoke();
    }
}
