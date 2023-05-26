using UnityEngine;

namespace Assets.Scripts.Boosters
{
    public class Coin : MonoBehaviour
    {
        public int Points;

        private void Awake()
        {

        }

        private void Take()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Take();
        }
    }
}