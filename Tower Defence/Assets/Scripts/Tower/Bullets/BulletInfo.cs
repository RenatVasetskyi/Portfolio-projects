using System;
using UnityEngine;

namespace Assets.Scripts.Tower.Bullets
{
    [Serializable]
    public class BulletInfo
    {
        public GameObject Prefab;
        public int Damage;
        public int Speed;
    }
}