using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Audio;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Boosters
{
    public class DestroyBooster : MonoBehaviour
    {
        [SerializeField] private Booster _booster;
        [SerializeField] private GameObject _destroyMeteorEffect;

        private float _destroyEffectDelay = 1f;

        private IAudioService _audioService;

        [Inject]
        public void Construct(IAudioService audioService) =>
            _audioService = audioService;

        private void Awake() =>
            _booster.OnTargetReached += Destroy;

        private void Destroy()
        {
            Destroy(gameObject);
            PlayEffect();
            _audioService.PlaySfx(SfxType.DestroyingMeteorite);
        }

        private void PlayEffect()
        {
            GameObject effect = Instantiate(_destroyMeteorEffect, transform.position, transform.rotation);
            Destroy(effect, _destroyEffectDelay);
        }
    }
}