using TMPro;
using UnityEngine;

namespace Vitality
{
    public class PlayerHealth : MonoBehaviour, IPlayerHealth
    {
        public int Hp;

        [SerializeField] private TextMeshProUGUI _playerHpText;

        public void ReducePlayerHp(int damage)
        {
            Hp -= damage;
            _playerHpText.text = Hp.ToString();
        }

        private void Awake()
        {
            _playerHpText.text = Hp.ToString();
        }
    }
}
