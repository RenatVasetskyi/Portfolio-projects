using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IPlayerHealth
{
    public int Hp;

    [SerializeField] private TextMeshProUGUI _playerHpText;

    private void Awake()
    {        
        _playerHpText.text = Hp.ToString();
    }

    void IPlayerHealth.ReducePlayerHp(int damage)
    {
        Hp -= damage;
        _playerHpText.text = Hp.ToString();
    }
}
