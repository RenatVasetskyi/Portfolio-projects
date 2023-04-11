using UnityEngine;

public class BulletHitTarget : MonoBehaviour
{
    private Bullet _bullet;
    private BulletCheckTarget _check;
    private BulletDestroyEffect _destroyEffect;

    public void Hit()
    {
        Destroy(gameObject);

        _destroyEffect.PlayEffect();

        _check.Target.GetComponent<VitalitySystem>().TakeDamage(_bullet.Damage);
    }

    private void Awake()
    {
        _bullet = GetComponent<Bullet>();
        _check = GetComponent<BulletCheckTarget>();
        _destroyEffect = GetComponent<BulletDestroyEffect>();
    }
}
