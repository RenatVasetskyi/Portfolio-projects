using UnityEngine;

public class BulletCheckTarget : MonoBehaviour
{
    public Transform Target { get; private set; }

    public void Seek(Transform target)
    {
        Target = target;
    }

    public void CheckTarget()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        CheckTarget();
    }
}
