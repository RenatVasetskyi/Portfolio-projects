using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Victory.Buttons
{
    public class MoveToNextLevelButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private IStateMachine _stateMachine;
        private ICurrentLevelSettingsProvider _currentLevelSettingsProvider;

        [Inject]
        public void Construct(IStateMachine stateMachine, ICurrentLevelSettingsProvider currentLevelSettingsProvider)
        {
            _stateMachine = stateMachine;
            _currentLevelSettingsProvider = currentLevelSettingsProvider;
        }

        private void Awake() =>
            _button.onClick.AddListener(EnterNextLevel);

        private void EnterNextLevel()
        {
            if (_currentLevelSettingsProvider
                .GetCurrentLevelSettings().NextLevel == LevelId.None)
                _stateMachine.Enter<LoadMainMenuState>();
            else
                _stateMachine
                    .Enter<LoadLevelState, string>(_currentLevelSettingsProvider
                        .GetCurrentLevelSettings().NextLevel.ToString());
        }
    }
}