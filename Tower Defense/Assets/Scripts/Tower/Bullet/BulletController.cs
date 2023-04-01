using UnityEngine;

namespace Bullet
{
    public class BulletController : MonoBehaviour
    {
        private IBulletShot _bulletShot;

        private void Awake()
        {
            _bulletShot = GetComponent<IBulletShot>();
        }

        private void Update()
        {
            _bulletShot.CheckTarget();
            _bulletShot.Move();
        }
    }
}
