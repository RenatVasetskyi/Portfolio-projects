using Assets.Scripts.Architecture.Main;
using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    public class LevelTransferButton : MonoBehaviour
    {
        public LevelId LevelId;

        [SerializeField] private Button _button;

        private ISceneLoader _sceneLoader;
        private IStateMachine _stateMachine;

        [Inject]
        public void Construct(ISceneLoader sceneLoader, IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        private void Awake() =>
            _button.onClick.AddListener(LoadLevel);

        private void LoadLevel() =>
            _sceneLoader.Load(LevelId.ToString(), OnLoaded);

        private void OnLoaded() =>
            _stateMachine.Enter<LoadLevelState>();
    }
}