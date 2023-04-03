using UnityEngine;

namespace Tower
{
    [CreateAssetMenu(fileName = "Tower", menuName = "Tower/DefaultTower")]
    public class TowerInfo : ScriptableObject
    {
        public TowerType TowerType;

        public GameObject TowerPrefab;
        public GameObject TowerModel;        

        public int Price;
        public float Damage;
        public float FireSpeed;
        public float AttackRange;
        public float UpgradePrice;
    }
}
