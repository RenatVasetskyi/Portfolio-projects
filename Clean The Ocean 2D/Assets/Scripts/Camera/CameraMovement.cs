using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _offset = new Vector3(0, 2.5f, -10);
    
    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {      
        transform.position = new Vector3(0, _target.position.y + _offset.y, _target.position.z + _offset.z);
    }
}
