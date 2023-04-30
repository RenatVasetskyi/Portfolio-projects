using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy.Animation
{
    public class EnemyAnimator : MonoBehaviour
    {
        private readonly int _deathHash = Animator.StringToHash("Death");

        [SerializeField] private Animator _animator;

        public void PlayDeath() =>
            _animator.SetTrigger(_deathHash);
    }
}