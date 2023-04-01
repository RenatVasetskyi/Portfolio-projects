using UnityEngine;

public interface IBulletShot
{
    public void Seek(Transform target);
    public void HitTarget();
    public void CheckTarget();
    public void Move();
}
