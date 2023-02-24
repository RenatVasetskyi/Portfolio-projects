using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem _combustion;
    [SerializeField] private ParticleSystem _explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.PlayerTag)
        {
            PlayExplosion();
            PlayExplosionSound();
        }
    }

    private void Start()
    {
        _combustion.Play();
    }

    private void PlayExplosion()
    {
        _combustion.Stop();
        _explosion.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void PlayExplosionSound()
    {
        AudioManager.Instance.PlaySfx(SfxType.Explosion);
        AudioManager.Instance.PlaySfx(SfxType.GameOver);
    }
}
