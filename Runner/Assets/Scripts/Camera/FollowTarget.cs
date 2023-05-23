using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private Vector3 _offset = new Vector3(0, 50, -40);

        private void LateUpdate() => Follow();

        private void Follow() =>
            transform.position = _target.position + _offset;
    }
}