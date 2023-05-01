using Assets.Scripts.Tower.Price;
using UnityEngine;

namespace Assets.Scripts.Tower.Selection
{
    public class TowerSelectionButtonHolder : MonoBehaviour
    {
        public TowerInfo Tower { get; set; }
        public SelectTowerButton SelectTowerButton;
        public ScaleButton ScaleButton;
        public DisplayTowerPrice DisplayTowerPrice;
    }
}