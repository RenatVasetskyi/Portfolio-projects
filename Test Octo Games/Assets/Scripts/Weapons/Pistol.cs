using Zenject;

namespace Assets.Scripts.Weapons
{
    public class Pistol : Firearms
    {
        private PlayerInput _playerInput;

        [Inject]
        public void Construct(PlayerInput playerInput) =>
            _playerInput = playerInput;

        private void OnEnable() =>
            _playerInput.Mouse.LeftClick.started += context => Shoot();
    }
}
