using Assets.Scripts.Architecture.Services.Factories.Booster;
using Assets.Scripts.Architecture.Services.Factories.Enemy;
using Assets.Scripts.Architecture.Services.Factories.Main;
using Assets.Scripts.Architecture.Services.Factories.Tower;
using Assets.Scripts.Architecture.Services.Factories.Tower.Bullet;
using Assets.Scripts.Architecture.Services.Factories.UI;
using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Enemy.Path;
using Assets.Scripts.Tower.Selection;
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
            BindEnemyFactory();
            BindStartPoint();
            BindFinish();
            BindWaveSystem();
            BindTowerFactory();
            BindMainLevelFactory();
            BindBulletFactory();
            BindStates();
            AddStatesToStateMachine();
            BindBoosterFactory();
        }

        private void BindBoosterFactory()
        {
            Container
                .Bind<IBoosterFactory>()
                .To<BoosterFactory>()
                .AsSingle();
        }

        private void BindBulletFactory()
        {
            Container
                .Bind<IBulletFactory>()
                .To<BulletFactory>()
                .AsSingle();
        }

        private void BindMainLevelFactory()
        {
            Container
                .Bind<IMainLevelFactory>()
                .To<MainLevelFactory>()
                .AsSingle();
        }

        private void BindTowerFactory()
        {
            Container
                .Bind<ITowerFactory>()
                .To<TowerFactory>()
                .AsSingle();
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
            Container.Bind<InitializeGameWorldState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();
            Container.Bind<GameOverState>().AsSingle();
        }

        private void AddStatesToStateMachine()
        {
            IStateMachine stateMachine = Container.Resolve<IStateMachine>();
            stateMachine.States.Add(typeof(InitializeGameWorldState), Container.Resolve<InitializeGameWorldState>());
            stateMachine.States.Add(typeof(GameLoopState), Container.Resolve<GameLoopState>());
            stateMachine.States.Add(typeof(GameOverState), Container.Resolve<GameOverState>());
        }
    }
}