using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Architecture.States.Interfaces;
using Assets.Scripts.Audio;
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

        private IAudioService _audioService;

        [Inject]
        public void Construct(IStateMachine stateMachine, IAudioService audioService)
        {
            StateMachine = stateMachine;
            _audioService = audioService;
        }

        private void Start() => Move();

        private void Move()
        {
            _audioService.PlaySfx(SfxType.OpenWindow);
            LeanTween.moveLocalY(gameObject, TargetPosition, _movementDuration).setEase(_ease);
        }
    }
}