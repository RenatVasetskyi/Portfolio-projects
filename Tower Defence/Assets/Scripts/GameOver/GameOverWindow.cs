using Assets.Scripts.Architecture.States.Interfaces;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.GameOver
{
    public class GameOverWindow : MonoBehaviour
    {
        private const int TargetPosition = 0;

        [SerializeField] private float _movementDuration;
        [SerializeField] private LeanTweenType _ease;

        public IStateMachine StateMachine { get; private set; }

        [Inject]
        public void Construct(IStateMachine stateMachine) =>
            StateMachine = stateMachine;

        private void Start() => Move();

        private void Move() =>
            LeanTween.moveLocalY(gameObject, TargetPosition, _movementDuration).setEase(_ease);
    }
}