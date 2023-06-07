using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public PlayerInput PlayerInput;

        [Inject]
        public void Construct(PlayerInput playerInput) =>
            PlayerInput = playerInput;
    }
}