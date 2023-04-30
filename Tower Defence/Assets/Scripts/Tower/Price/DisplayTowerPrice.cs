using Assets.Scripts.Tower.Selection;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Tower.Price
{
    public class DisplayTowerPrice : MonoBehaviour
    {
        [SerializeField] private TowerSelectionButtonHolder _holder;
        [SerializeField] private TextMeshProUGUI _priceText;

        private void Start() =>
            DisplayText();

        private void DisplayText() =>
            _priceText.text = _holder.Tower.Price.ToString();
    }
}