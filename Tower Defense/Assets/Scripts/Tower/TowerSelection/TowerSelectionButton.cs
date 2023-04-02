using UnityEngine;

namespace Tower
{
    [CreateAssetMenu(fileName = "TowerSelectionButton", menuName = "TowerSelectionButton/DefaultButton")]
    public class TowerSelectionButton : ScriptableObject
    {
        public GameObject Button;
        public GameObject TowerPrefab;
        public GameObject TowerModel;
        public TowerType TowerType;

        public int Price;
        public float Damage;
        public float FireSpeed;
        public float AttackRange;
        public float UpgradePrice;
    }
}