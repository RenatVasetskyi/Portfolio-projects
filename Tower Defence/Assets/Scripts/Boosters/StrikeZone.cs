using Assets.Scripts.Architecture.Services.Factories.Booster;
using Assets.Scripts.Architecture.Services.Factories.UI;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Audio;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.Scripts.Boosters
{
    public class StrikeZone : MonoBehaviour
    {
        private ILevelUIFactory _levelUIFactory;
        private IBoosterFactory _boosterFactory;
        private IAudioService _audioService;

        private Vector2 _mousePosition;
        private Ray _ray;
        private int _maxRaycastDistance = 200;
        private int _strikeZoneLayer = 1 << 8;

        [Inject]
        public void Construct(ILevelUIFactory levelUIFactory, IBoosterFactory boosterFactory, IAudioService audioService)
        {
            _levelUIFactory = levelUIFactory;
            _boosterFactory = boosterFactory;
            _audioService = audioService;
        }

        private void OnMouseDown()
        {
            foreach (BoosterButton boosterButton in _levelUIFactory.BoosterHolder.BoosterButtons)
            {
                if (boosterButton.IsActivated)
                {
                    boosterButton.OffButton();
                    Booster booster = _boosterFactory.CreateBooster(boosterButton.BoosterType, GetBoosterSpawnPosition(), transform.rotation, transform);
                    StartCoroutine(booster?.Move(GetTargetPosition()));
                    _audioService.PlaySfx(SfxType.FlyingMeteorite);
                }
            }
        }

        private Vector3 GetTargetPosition()
        {
            _mousePosition = Mouse.current.position.ReadValue();
            _ray = UnityEngine.Camera.main.ScreenPointToRay(_mousePosition);

            if (Physics.Raycast(_ray, out RaycastHit hit, _maxRaycastDistance, _strikeZoneLayer))
                return hit.point;
            else
                return default;
        }

        private Vector3 GetBoosterSpawnPosition()
        {
            return new Vector3(UnityEngine.Camera.main.transform.position.x 
                               + 10, UnityEngine.Camera.main.transform.position.y 
                                     + 40, UnityEngine.Camera.main.transform.position.z);
        }
    }
}