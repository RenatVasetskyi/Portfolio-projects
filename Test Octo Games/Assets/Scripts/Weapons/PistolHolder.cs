using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class PistolHolder : MonoBehaviour
    {
        private static int RaiseHand = Animator.StringToHash("RaiseHand");
        private static int LowerHand = Animator.StringToHash("LowerHand");

        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private Animator _animator;

        private void OnEnable()
        {
            _playerHealth.PlayerInput.Mouse.RightClick.started += context => RaiseTheGun();
            _playerHealth.PlayerInput.Mouse.RightClick.canceled += context => LowerTheGun();
        }

        private void RaiseTheGun() =>
            _animator.SetTrigger(RaiseHand);

        private void LowerTheGun() => 
            _animator.SetTrigger(LowerHand);
    }
}