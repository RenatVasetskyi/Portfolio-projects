using TMPro;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    public int CoinForLvl;

    [SerializeField] private TextMeshProUGUI _coinsText;

    private void Awake()
    {
        _coinsText.text = CoinForLvl.ToString();
    }
}
