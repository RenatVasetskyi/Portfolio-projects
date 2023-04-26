using System;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Data.Levels;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Architecture.Services
{
    public class LocalCoinService : ILocalCoinService
    {
        public event Action OnCoinsChanged;

        private readonly AllLevelsSettings _levels;

        public int Coins { get; set; }

        public LocalCoinService(AllLevelsSettings levels)
        {
            _levels = levels;
            SetCoins();
        }

        public void Buy(int price)
        {
            Coins -= price;
            OnCoinsChanged?.Invoke();
        }

        private void SetCoins()
        {
            LevelSettings currentLevel = GetCurrentLevel();
            Coins = currentLevel.Coins;
        }

        private LevelSettings GetCurrentLevel() => 
            _levels.Levels.Find(x=>x.Id.ToString() == SceneManager.GetActiveScene().name);
    }
}