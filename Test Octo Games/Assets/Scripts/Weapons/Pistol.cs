using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Pistol : Firearms
    {
        [SerializeField] private PlayerHealth _playerHealth;

        private void OnEnable() =>
            _playerHealth.PlayerInput.Mouse.LeftClick.started += context => Shoot();
    }
}
