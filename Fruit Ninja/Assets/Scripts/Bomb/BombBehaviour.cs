using UnityEngine;
using Audio;

public class BombBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.PlayerTag)
        {
            AudioManager.Instance.PlaySfx(SfxType.Explosion);
            Explosion();
            Events.SendOnBombExploded();        
        }
    }

    private void Explosion()
    {       
        _particleSystem.Play();      
    }
}
