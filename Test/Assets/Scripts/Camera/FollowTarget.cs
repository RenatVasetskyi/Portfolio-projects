using Assets.Scripts.Architecture.Services;
using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class FollowTarget : MonoBehaviour
    { 
        [SerializeField] private float _offsetY;

        private Transform _target;

        private void Awake() =>
            _target = AllServices.Container.Single<IMainFactory>().Car;

        private void LateUpdate() =>
            transform.position = new Vector3(transform.position.x, _target.position.y + _offsetY, transform.position.z);
    }
}