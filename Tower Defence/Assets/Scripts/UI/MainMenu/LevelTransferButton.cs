using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.MainMenu
{
    public class LevelTransferButton : MonoBehaviour
    {
        public LevelId LevelId;

        [SerializeField] private Button _button;

        private IStateMachine _stateMachine;

        [Inject]
        public void Construct(IStateMachine stateMachine) =>
            _stateMachine = stateMachine;

        private void Awake() =>
            _button.onClick.AddListener(EnterLoadLevelState);

        private void EnterLoadLevelState() =>
            _stateMachine.Enter<LoadLevelState, string>(LevelId.ToString());
    }
}