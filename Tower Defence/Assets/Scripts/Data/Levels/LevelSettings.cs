using System;
using Assets.Scripts.Waves;
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

        [Header("GeneralSettings")] 
        public int Coins;
        public int Hp;

        [Header("WaveSettings")]
        public WaveSettings WaveSettings;
    }
}