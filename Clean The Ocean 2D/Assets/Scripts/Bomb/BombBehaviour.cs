using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.PlayerTag)
        {
            PlayExplosion();
            PlayExplosionSound();
        }
    }

    private void PlayExplosion()
    {
        gameObject.GetComponentInChildren<ParticleSystem>().Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void PlayExplosionSound()
    {
        AudioManager.Instance.PlaySfx(SfxType.Explosion);
        AudioManager.Instance.PlaySfx(SfxType.GameOver);
    }
}
