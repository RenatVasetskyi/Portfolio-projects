using System;
using Assets.Scripts.Data;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Architecture.Services
{
    public class InputService : IInputService
    {
        private readonly PlayerInput _playerInput;

        public event StartTouch OnTouchStarted;
        public event EndTouch OnTouchEnded;

        public delegate void StartTouch(Vector2 position, float time);
        public delegate void EndTouch(Vector2 position, float time);

        private UnityEngine.Camera _camera;

        public InputService(PlayerInput playerInput)
        {
            _camera = UnityEngine.Camera.main;

            _playerInput = playerInput;
            _playerInput.Swipes.PrimaryContact.started += context => StartTouchPrimary(context);
            _playerInput.Swipes.PrimaryContact.canceled += context => EndTouchPrimary(context);
        }

        public void SetCurrentCamera(UnityEngine.Camera camera) =>
            _camera = camera;

        private void StartTouchPrimary(InputAction.CallbackContext context) =>
            OnTouchStarted?.Invoke(Extentions
                .ScreenToWorld(_playerInput.Swipes.PrimaryPosition
                    .ReadValue<Vector2>(), _camera), (float)context.startTime);

        private void EndTouchPrimary(InputAction.CallbackContext context) =>
            OnTouchEnded?.Invoke(Extentions
                .ScreenToWorld(_playerInput.Swipes.PrimaryPosition
                    .ReadValue<Vector2>(), _camera), (float)context.startTime);
    }
}