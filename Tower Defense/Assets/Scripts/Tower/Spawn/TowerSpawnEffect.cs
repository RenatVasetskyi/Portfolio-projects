using UnityEngine;

namespace Tower
{
    public class TowerSpawnEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _spawnEffect;

        private void Start()
        {
            _spawnEffect.Play();
        }
    }
}
