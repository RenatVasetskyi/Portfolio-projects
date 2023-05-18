using Assets.Scripts.Architecture.Services.Factories.Booster;
using Assets.Scripts.Architecture.Services.Factories.UI;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Audio;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.Scripts.Boosters.Meteorite
{
    public class MeteorStrikeZone : MonoBehaviour
    {
        private IUIFactory _uiFactory;
        private IBoosterFactory _boosterFactory;
        private IAudioService _audioService;

        private Vector2 _mousePosition;
        private Ray _ray;
        private int _maxRaycastDistance = 200;
        private int _strikeZoneLayer = 1 << 8;

        private UnityEngine.Camera _camera;

        [Inject]
        public void Construct(IUIFactory uiFactory, IBoosterFactory boosterFactory, IAudioService audioService)
        {
            _uiFactory = uiFactory;
            _boosterFactory = boosterFactory;
            _audioService = audioService;
        }

        private void Awake()
            => _camera = UnityEngine.Camera.main;

        private void OnMouseDown()
        {
            foreach (BoosterButton boosterButton in _uiFactory.BoosterHolder.BoosterButtons)
            {
                if (boosterButton.IsActivated)
                {
                    boosterButton.OffButton();
                    MovableBooster booster = _boosterFactory.CreateMovableBooster(boosterButton.BoosterType, GetBoosterSpawnPosition(), transform.rotation, transform);
                    StartCoroutine(booster?.Move(GetTargetPosition()));
                    _audioService.PlaySfx(SfxType.FlyingMeteorite);
                }
            }
        }

        private Vector3 GetTargetPosition()
        {
            _mousePosition = Mouse.current.position.ReadValue();
            _ray = _camera.ScreenPointToRay(_mousePosition);

            if (Physics.Raycast(_ray, out RaycastHit hit, _maxRaycastDistance, _strikeZoneLayer))
                return hit.point;
            else
                return default;
        }

        private Vector3 GetBoosterSpawnPosition()
        {
            return new Vector3(_camera.transform.position.x 
                               + 10, _camera.transform.position.y 
                                     + 40, _camera.transform.position.z);
        }
    }
}