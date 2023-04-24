using System;
using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Architecture.Services
{
    [Serializable]
    public class ButtonConfig
    {
        public LevelId Id;
        public GameObject Prefab;
    }
}