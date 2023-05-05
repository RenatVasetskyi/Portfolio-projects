using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class DestroyBooster : MonoBehaviour
    {
        [SerializeField] private Booster _booster;

        private void Awake() =>
            _booster.OnTargetReached += Destroy;

        private void Destroy() =>
            Destroy(gameObject);
    }
}