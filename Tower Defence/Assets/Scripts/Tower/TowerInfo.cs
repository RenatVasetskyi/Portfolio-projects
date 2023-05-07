using System;
using Assets.Scripts.Tower.Bullets;
using UnityEngine;

namespace Assets.Scripts.Tower
{
    [Serializable]
    public class TowerInfo
    {
        public TowerType TowerType;

        public GameObject TowerPrefab;
        public GameObject TowerModel;

        public BulletInfo Bullet;

        public int Price;
        public int UpgradePrice;
        public int AttackRange;
        public int RotateSpeed;
        public float FireSpeed;
    }
}