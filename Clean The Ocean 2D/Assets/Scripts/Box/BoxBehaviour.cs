using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.PlayerTag)
        {
            collision.enabled = false;
            PlayExplosion();
            PlayExplosionSound();
        }
    }

    private void PlayExplosion()
    {
        _destroyBox.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void PlayExplosionSound()
    {
        AudioManager.Instance.PlaySfx(SfxType.BoxDestroying);
        AudioManager.Instance.PlaySfx(SfxType.GameOver);
    }
}
