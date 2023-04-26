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
        
        private Button _button;

        private IStateMachine _stateMachine;

        [Inject]
        public void Construct(IStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(LoadLevel);
        }

        private void LoadLevel() =>
            _stateMachine.Enter<LoadLevelState, string>(LevelId.ToString());
    }
}