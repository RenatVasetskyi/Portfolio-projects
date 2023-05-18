using Assets.Scripts.Architecture.Services.Interfaces;
using Assets.Scripts.Audio;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Boosters.Meteorite
{
    public class DestroyMeteor : MonoBehaviour
    {
        [SerializeField] private Meteor _meteor;
        [SerializeField] private GameObject _destroyMeteorEffect;

        private float _destroyEffectDelay = 1f;

        private IAudioService _audioService;

        [Inject]
        public void Construct(IAudioService audioService) =>
            _audioService = audioService;

        private void Awake() =>
            _meteor.OnTargetReached += Destroy;

        private void OnDestroy() =>
            _meteor.OnTargetReached -= Destroy;

        private void Destroy()
        {
            _audioService.PlaySfx(SfxType.DestroyingMeteorite);
            Destroy(gameObject);
            PlayEffect();
        }

        private void PlayEffect()
        {
            GameObject effect = Instantiate(_destroyMeteorEffect, transform.position, transform.rotation);
            Destroy(effect, _destroyEffectDelay);
        }
    }
}