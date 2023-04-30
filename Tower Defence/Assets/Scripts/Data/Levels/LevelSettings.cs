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

        [Header("General Settings")] 
        public int Coins;
        public int Hp;

        [Header("Wave Settings")]
        public WaveSettings WaveSettings;

        [Header("Tower selection buttons")]
        public TowerSelectionButtonsHolder TowerSelectionButtons;
    }
}