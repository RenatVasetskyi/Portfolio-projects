using UnityEngine;

[CreateAssetMenu(fileName = "TowerSelectionButton", menuName = "TowerSelectionButton/DefaultButton")]
public class TowerSelectionButton : ScriptableObject
{
    public GameObject Button;
    public TowerInfo Tower;
}