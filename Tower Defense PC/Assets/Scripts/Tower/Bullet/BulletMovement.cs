using UnityEngine;

public class BulletMovement : MonoBehaviour, IMovable
{
    private Bullet _bullet;
    private BulletCheckTarget _check;
    private BulletHitTarget _hit;

    public void Move()
    {
        if (_check.Target == null)
            return;

        Vector3 direction = _check.Target.position - transform.position;
        float distanceThisFrame = _bullet.BulletSpeed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            _hit.Hit();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    private void Awake()
    {
        _check = GetComponent<BulletCheckTarget>();
        _bullet = GetComponent<Bullet>();
        _hit = GetComponent<BulletHitTarget>();
    }

    private void Update()
    {
        Move();
    }
}
