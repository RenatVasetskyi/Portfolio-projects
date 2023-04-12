using UnityEngine;

public class CameraConstantWidth : MonoBehaviour
{
    public Vector2 DefaultResolution = new Vector2(1920, 1080);
    [Range(0f, 1f)] public float WidthOrHeight = 0;

    private Camera _camera;

    private float _initialSize;
    private float _targetAspect;

    private float _initialFov;
    private float _horizontalFov;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _initialSize = _camera.orthographicSize;

        _targetAspect = DefaultResolution.x / DefaultResolution.y;

        _initialFov = _camera.fieldOfView;
        _horizontalFov = CalculateVerticalFov(_initialFov, 1 / _targetAspect);
    }

    private void LateUpdate()
    {
        CameraProjection();
    }

    private void CameraProjection()
    {
        if (_camera.orthographic)
        {
            float constantWidthSize = _initialSize * (_targetAspect / _camera.aspect);
            _camera.orthographicSize = Mathf.Lerp(constantWidthSize, _initialSize, WidthOrHeight);
        }
        else
        {
            float constantWidthFov = CalculateVerticalFov(_horizontalFov, _camera.aspect);
            _camera.fieldOfView = Mathf.Lerp(constantWidthFov, _initialFov, WidthOrHeight);
        }
    }

    private float CalculateVerticalFov(float horizontalFovInDegrees, float aspectRatio)
    {
        float horizontalFovInRadians = horizontalFovInDegrees * Mathf.Deg2Rad;

        float verticalFovInRadians = 2 * Mathf.Atan(Mathf.Tan(horizontalFovInRadians / 2) / aspectRatio);

        return verticalFovInRadians * Mathf.Rad2Deg;
    }
}
