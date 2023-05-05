using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class DestroyBooster : MonoBehaviour
    {
        [SerializeField] private Booster _booster;
        [SerializeField] private GameObject _destroyMeteorEffect;

        private float _destroyEffectDelay = 1f;

        private void Awake() =>
            _booster.OnTargetReached += Destroy;

        private void Destroy()
        {
            Destroy(gameObject);
            PlayEffect();
        }

        public void PlayEffect()
        {
            GameObject effect = Instantiate(_destroyMeteorEffect, transform.position, transform.rotation);
            Destroy(effect, _destroyEffectDelay);
        }
    }
}