using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Hp;

    [SerializeField] private TextMeshProUGUI _playerHpText;

    private void Awake()
    {
        EventManager.PlayerHpChanged.AddListener(ReducePlayerHp);
        _playerHpText.text = Hp.ToString();
    }

    private void ReducePlayerHp(int damage)
    {
        Hp -= damage;
        _playerHpText.text = Hp.ToString();
    }
}
