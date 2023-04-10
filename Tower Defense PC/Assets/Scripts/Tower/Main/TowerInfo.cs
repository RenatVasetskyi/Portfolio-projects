using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "Tower/DefaultTower")]
public class TowerInfo : ScriptableObject
{
    public TowerType TowerType;

    public GameObject TowerPrefab;   
    public GameObject TowerModel;

    public int RotateSpeed;
    public int Price;
    public int Damage;
    public float FireSpeed;
    public int AttackRange;
    public int UpgradePrice;
}
