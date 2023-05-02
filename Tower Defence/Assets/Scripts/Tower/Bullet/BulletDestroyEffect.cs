using UnityEngine;

namespace Assets.Scripts.Tower.Bullet
{
    public class BulletDestroyEffect : MonoBehaviour
    {
        [SerializeField] private GameObject _destroyBulletEffect;

        private float _destroyEffectDelay = 1f;

        public void PlayEffect()
        {
            GameObject effect = Instantiate(_destroyBulletEffect, transform.position, transform.rotation);
            Destroy(effect, _destroyEffectDelay);
        }
    }
}