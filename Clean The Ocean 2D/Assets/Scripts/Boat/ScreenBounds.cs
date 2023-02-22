using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    private Vector3 _screenBounds;
    private EdgeCollider2D _edgeCollider;

    private float _objectWidth;    

    void Start()
    {
        _edgeCollider = GetComponent<EdgeCollider2D>();
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        _objectWidth = _edgeCollider.bounds.extents.x;           
    }

    void LateUpdate()
    {      
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -_screenBounds.x + _objectWidth, _screenBounds.x - _objectWidth);       
        transform.position = viewPos;
    }
}
