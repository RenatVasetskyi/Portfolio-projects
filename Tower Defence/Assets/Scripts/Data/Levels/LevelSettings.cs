using System;
using System.Collections.Generic;
using Assets.Scripts.Boosters;
using Assets.Scripts.Data.TowerSelection;
using Assets.Scripts.Waves;
using UnityEngine;

namespace Assets.Scripts.Data.Levels
{
    [Serializable]
    public class LevelSettings
    {
        public LevelId Id;

        [Header("Prefabs")] 
        public List<GameObject> MainLevelUIElements;

        //public GameObject StartWavesButton;
        //public GameObject CoinsCounter;
        //public GameObject WaveCounter;
        //public GameObject PlayersHp;

        [Header("General Settings")] 
        public int Coins;
        public int Hp;

        [Header("Wave Settings")]
        public WaveSettings WaveSettings;

        [Header("Tower selection buttons")]
        public TowerSelectionButtonsHolder TowerSelectionButtons;

        [Header("Boosters")]
        public List<BoosterButton> Boosters;
    }
}