using UnityEngine;

[CreateAssetMenu(fileName = "TowerSelectionButton", menuName = "TowerSelectionButton/DefaultButton")]
public class TowerSelectionButton : ScriptableObject
{
    public GameObject Button;
    public GameObject TowerPrefab;
    public GameObject TowerModel;
    public TowerType TowerType;
    public int Price;
}
