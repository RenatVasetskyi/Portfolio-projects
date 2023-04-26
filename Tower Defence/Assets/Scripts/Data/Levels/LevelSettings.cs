using System;
using UnityEngine;

namespace Assets.Scripts.Data.Levels
{
    [Serializable]
    public class LevelSettings
    {
        public LevelId Id;

        [Header("Prefabs")]
        public GameObject StartWavesButton;
        public GameObject CoinsCounter;
        public GameObject WaveCounter;
        public GameObject PlayersHp;

        [Header("Settings")] 
        public int Coins;
    }
}