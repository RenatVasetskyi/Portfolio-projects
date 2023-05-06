using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.GameOver.Buttons
{
    public class BackToMenuButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private IStateMachine _stateMachine;

        [Inject]
        public void Construct(IStateMachine stateMachine) =>
            _stateMachine = stateMachine;

        private void Awake() =>
            _button.onClick.AddListener(EnterLoadLevelState);

        private void EnterLoadLevelState() =>
            _stateMachine.Enter<LoadMainMenuState>();
    }
}