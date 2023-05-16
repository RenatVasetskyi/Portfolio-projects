using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Audio;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI
{
    public class MovableWindow : MonoBehaviour
    {
        private const int TargetPosition = 0;

        [SerializeField] private float _movementDuration;
        [SerializeField] private LeanTweenType _ease;

        private IAudioService _audioService;

        [Inject]
        public void Construct(IAudioService audioService) =>
            _audioService = audioService;

        private void Start() => Move();

        private void Move()
        {
            _audioService.PlaySfx(SfxType.OpenWindow);
            LeanTween.moveLocalY(gameObject, TargetPosition, _movementDuration).setEase(_ease);
        }
    }
}