using Assets.Scripts.Architecture.Services;
using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Data;
using Assets.Scripts.Weapons;
using Opsive.UltimateCharacterController.Camera;
using UnityEngine;

namespace Assets.Scripts.Architecture.States
{
    public class LoadGameState : IState
    {
        private const string GameScene = "Game";

        private readonly ISceneLoader _sceneLoader;
        private readonly IBaseFactory _baseFactory;

        public LoadGameState(ISceneLoader sceneLoader, IBaseFactory baseFactory)
        {
            _sceneLoader = sceneLoader;
            _baseFactory = baseFactory;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _sceneLoader.Load(GameScene, InitializeGameWorld);
        }

        private void InitializeGameWorld()
        {
            _baseFactory.CreateBaseObjectWithObject<Transform>(AssetPath.Environment);

            _baseFactory.CreatePlayer();

            Transform cameraParent = _baseFactory.CreateBaseObjectWithObject<Transform>(AssetPath.CameraParent);
            CameraController camera = _baseFactory.CreateBaseObjectWithContainer<CameraController>(AssetPath.Camera, cameraParent);
            camera.Character = _baseFactory.Player.gameObject;
        }
    }
}