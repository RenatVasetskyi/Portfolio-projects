using UnityEngine;
using MyEvents;
using Vitality;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayerHealth _playerHealth;

        private void Awake()
        {
            _playerHealth = GetComponent<IPlayerHealth>();
            Events.OnPlayerHpChanged.AddListener(_playerHealth.ReducePlayerHp);
        }
    }
}
