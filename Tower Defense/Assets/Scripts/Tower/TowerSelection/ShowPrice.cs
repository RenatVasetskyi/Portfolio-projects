using TMPro;
using Tower;
using UnityEngine;

public class ShowPrice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _priceText;

    private ButtonHolder _holder;

    private void Start()
    {
        _holder = GetComponent<ButtonHolder>();
        Show();
    }

    private void Show()
    {
        _priceText.text = _holder.Price.ToString();
    }
}
