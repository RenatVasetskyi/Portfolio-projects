using UnityEngine;
using MyEvents;

namespace Enemy
{
    public class DestroyEnemy : MonoBehaviour
    {
        private void Awake()
        {
            Events.OnGameOver.AddListener(Destroy);
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
