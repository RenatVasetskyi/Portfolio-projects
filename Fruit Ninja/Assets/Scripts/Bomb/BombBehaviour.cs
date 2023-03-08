using System.Collections;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private float _destroyDelay = 1.5f;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.PlayerTag)
        {
            AudioManager.Instance.PlaySfx(SfxType.Explosion);
            Explosion();
            Events.SendOnBombExploded();
            StartCoroutine(DestoyBomb());
        }
    }

    private void Explosion()
    {       
        _particleSystem.Play();      
    }

    private IEnumerator DestoyBomb()
    {
        yield return new WaitForSeconds(_destroyDelay);
        Destroy(gameObject);
    }
}
