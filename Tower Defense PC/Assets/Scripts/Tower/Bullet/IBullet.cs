using UnityEngine;

public interface IBullet
{
    public void Seek(Transform target);
    public void HitTarget();
    public void CheckTarget();
    public void Move();
}
