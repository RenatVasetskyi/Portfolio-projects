using UnityEngine;

namespace Tower
{
    [CreateAssetMenu(fileName = "TowerSelectionButton", menuName = "TowerSelectionButton/DefaultButton")]
    public class TowerSelectionButton : ScriptableObject
    {
        public GameObject Button;
        public Tower Tower;     
    }
}
