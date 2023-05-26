using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _offsetY;

        private void LateUpdate() =>
            transform.position = new Vector3(transform.position.x, _target.position.y + _offsetY, transform.position.z);
    }
}