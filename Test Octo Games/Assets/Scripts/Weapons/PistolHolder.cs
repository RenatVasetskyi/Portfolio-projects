using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class PistolHolder : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;

        private void OnEnable()
        {
            _playerHealth.PlayerInput.Mouse.RightClick.started += context => RaiseTheGun();
            _playerHealth.PlayerInput.Mouse.RightClick.canceled += context => LowerTheGun();
        }

        private void RaiseTheGun()
        {
            Debug.Log("Raise");
        }

        private void LowerTheGun()
        {
            Debug.Log("Lower");
        }
    }
}