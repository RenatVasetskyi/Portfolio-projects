using UnityEngine;
using Events;

namespace Enemy
{
    public class DestroyEnemy : MonoBehaviour
    {
        private void Awake()
        {
            EventManager.GameOver.AddListener(Destroy);
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
