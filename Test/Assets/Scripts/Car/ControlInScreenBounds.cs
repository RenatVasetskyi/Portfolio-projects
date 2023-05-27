using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Car
{
    public class ControlInScreenBounds : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _boxCollider;

        private Vector3 _screenBounds;
        private UnityEngine.Camera _camera;
        private float _objectWidth;

        void Start()
        {
            _camera = UnityEngine.Camera.main;
            _screenBounds = new Vector2(Screen.width, Screen.height).ToWorldPoint(_camera);
            _objectWidth = _boxCollider.bounds.extents.x;
        }

        void LateUpdate()
        {
            Vector3 viewPosition = transform.position;
            viewPosition.x = Mathf.Clamp(viewPosition.x, -_screenBounds.x + _objectWidth, _screenBounds.x - _objectWidth);
            transform.position = viewPosition;
        }
    }
}