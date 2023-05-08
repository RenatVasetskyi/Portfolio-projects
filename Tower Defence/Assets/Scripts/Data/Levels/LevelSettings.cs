using System;
using System.Collections.Generic;
using Assets.Scripts.Audio;
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

        [Header("General Settings")] 
        public int Coins;
        public int Hp;

        [Header("Wave Settings")]
        public WaveSettings WaveSettings;

        [Header("Tower selection buttons")]
        public TowerSelectionButtonsHolder TowerSelectionButtons;

        [Header("Boosters")]
        public List<BoosterButton> Boosters;

        [Header("Music")]
        public MusicType MusicType;

        [Header("EnemyPath")] 
        public Vector3 SpawnPoint;
        public Vector3 FinishPoint;
    }
}