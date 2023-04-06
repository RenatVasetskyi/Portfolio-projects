using TMPro;
using UnityEngine;

public class DisplayTowerPrice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _priceText;

    private ButtonHolder _holder;

    private void Start()
    {
        _holder = GetComponent<ButtonHolder>();
        DisplayText();
    }

    private void DisplayText()
    {
        _priceText.text = _holder.Tower.Price.ToString();
    }
}
