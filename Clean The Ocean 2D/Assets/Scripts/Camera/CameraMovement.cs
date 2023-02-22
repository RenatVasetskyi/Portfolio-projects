using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _offset = new Vector3(0, 4, -10);
    
    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        var nextPosition = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime);
        transform.position = nextPosition;
    }
}
