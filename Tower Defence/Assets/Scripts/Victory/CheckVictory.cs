using System.Collections;
using Assets.Scripts.Architecture.Services.Factories.Enemies;
using Assets.Scripts.Architecture.States;
using Assets.Scripts.Architecture.States.Interfaces;
using ModestTree;
using UnityEngine;

namespace Assets.Scripts.Victory
{
    public class CheckVictory : ICheckVictory
    {
        private float _checkFrequency = 3f;

        private IEnemyFactory _enemyFactory;
        private IStateMachine _stateMachine;

        public CheckVictory(IStateMachine stateMachine, IEnemyFactory enemyFactory)
        {
            _stateMachine = stateMachine;
            _enemyFactory = enemyFactory;
        }

        public IEnumerator Check()
        {
            while (true)
            {
                if (CheckAreAllEnemiesDied())
                {
                    _stateMachine.Enter<VictoryState>();
                    yield break;
                }

                yield return new WaitForSeconds(_checkFrequency);
            }
        }

        private bool CheckAreAllEnemiesDied() =>
            _enemyFactory.EnemyParent.Enemies.IsEmpty();
    }
}