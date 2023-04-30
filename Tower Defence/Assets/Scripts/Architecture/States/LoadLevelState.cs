using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.SceneManagement;
using Assets.Scripts.UI.Loading;

namespace Assets.Scripts.Architecture.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly LoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly IStateMachine _stateMachine;

        public LoadLevelState(IStateMachine stateMachine, LoadingCurtain loadingCurtain, ISceneLoader sceneLoader)
        {
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
        }

        public void Exit() =>
            _loadingCurtain.Hide();

        public void Enter(string nextScene)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(nextScene, OnLoaded);
        }

        private void OnLoaded() =>
            _stateMachine.Enter<InitializeGameWorld>();
    }
}