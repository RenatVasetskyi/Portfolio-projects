using System;
using UnityEngine;

namespace Assets.Scripts.Tower.TowerSelection
{
    [Serializable]
    public class TowerInfo
    {
        public TowerType TowerType;

        public GameObject TowerPrefab;
        public GameObject TowerModel;

        //public BulletInfo Bullet;

        public int Price;
        public int UpgradePrice;
        public int AttackRange;
        public float FireSpeed;
        public int RotateSpeed;
    }
}