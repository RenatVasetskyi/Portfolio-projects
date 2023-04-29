using Assets.Scripts.Architecture.Services.Factories;
using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.EnemyPath;
using Assets.Scripts.Waves;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Architecture.Installers
{
    public class LocalInstaller : MonoInstaller
    {
        [SerializeField] private StartPoint _startPoint;
        [SerializeField] private Finish _finish;

        public override void InstallBindings()
        {
            BindLevelUIFactory();
            BindStates();
            AddStatesToStateMachine();
            BindEnemyFactory();
            BindStartPoint();
            BindFinish();
            BindWaveSystem();
        }

        private void BindLevelUIFactory()
        {
            Container
                .Bind<ILevelUIFactory>()
                .To<LevelUIFactory>()
                .AsSingle();
        }

        private void BindWaveSystem()
        {
            Container
                .Bind<IWaveSystem>()
                .To<WaveSystem>()
                .AsSingle();
        }

        private void BindFinish()
        {
            Container.Bind<Finish>()
                .FromInstance(_finish)
                .AsSingle();
        }

        private void BindStartPoint()
        {
            Container
                .Bind<StartPoint>()
                .FromInstance(_startPoint)
                .AsSingle();
        }

        private void BindEnemyFactory()
        {
            Container
                .Bind<IEnemyFactory>()
                .To<EnemyFactory>()
                .AsSingle();
        }

        private void BindStates()
        {
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();
        }

        private void AddStatesToStateMachine()
        {
            IStateMachine stateMachine = Container.Resolve<IStateMachine>();
            stateMachine.States.Add(typeof(LoadLevelState), Container.Resolve<LoadLevelState>());
            stateMachine.States.Add(typeof(GameLoopState), Container.Resolve<GameLoopState>());
        }
    }
}