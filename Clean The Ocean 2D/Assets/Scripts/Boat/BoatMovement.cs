using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private float _directionX;

    private float _horizontalSpeed = 1f;
    private float _verticalSpeed = 2f;

    public void StopBoat()
    {
        _horizontalSpeed = 0;
        _verticalSpeed = 0;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveForward();

        _directionX = Input.acceleration.x * _horizontalSpeed;
    }

    void FixedUpdate()
    {
        HorizontalMove();
    }

    private void HorizontalMove()
    {
        _rigidbody.velocity = new Vector3(_directionX, 0f);
    }

    private void MoveForward()
    {
        transform.Translate(Vector2.up * _verticalSpeed * Time.deltaTime, Space.World);
    }
}
