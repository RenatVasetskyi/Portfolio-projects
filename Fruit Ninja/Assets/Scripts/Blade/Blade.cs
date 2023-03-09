using UnityEngine;

public class Blade : MonoBehaviour
{
    public Vector3 Direction { get; private set; }

    public float SliceForce = 7f;
    public float MinSliceVelocity = 0.01f;

    [SerializeField] private Camera _camera;
    
    private Collider _bladeCollider;
    private TrailRenderer _trailRenderer;

    private bool _slicing;

    private void Awake()
    {     
        _bladeCollider = GetComponent<Collider>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    private void Update()
    {
        if (/*Input.touchCount*/Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        }      
        else if(Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }
        else if (_slicing == true)
        {
            ContinueSlicing();
        }
    }

    private void OnDisable()
    {
        StopSlicing();
    }

    private void OnEnable()
    {
        StopSlicing();
    }

    private void StartSlicing()
    {      
        Vector3 newPosition = _camera.ScreenToWorldPoint(/*Input.GetTouch(0).position*/Input.mousePosition);
        newPosition.z = 0;

        transform.position = newPosition;

        _slicing = true;
        _bladeCollider.enabled = true;
        _trailRenderer.enabled = true;
        _trailRenderer.Clear();
    }

    private void StopSlicing()
    {
        _slicing = false;
        _bladeCollider.enabled = false;
        _trailRenderer.enabled = true;      
    }

    private void ContinueSlicing()
    {       
        Vector3 newPosition = _camera.ScreenToWorldPoint(/*Input.GetTouch(0).position*/Input.mousePosition);
        newPosition.z = 0;

        Direction = newPosition - transform.position;

        float velocity = Direction.magnitude / Time.deltaTime; 
        _bladeCollider.enabled = velocity > MinSliceVelocity;

        transform.position = newPosition;
    }
}
