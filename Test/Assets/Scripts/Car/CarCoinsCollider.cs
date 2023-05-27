using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Car
{
    public class CarCoinsCollider : MonoBehaviour
    {
        public BoxCollider2D Collider;

        public void StartMagnetizing(Vector2 sizeIncreasing, float duration) =>
            StartCoroutine(Magnetize(sizeIncreasing, duration));

        private IEnumerator Magnetize(Vector2 sizeIncreasing, float duration)
        {
            Collider.size += sizeIncreasing;
            yield return new WaitForSeconds(duration);
            Collider.size -= sizeIncreasing;
        }
    }
}