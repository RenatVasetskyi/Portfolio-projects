using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeBomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.BombTag)
        {
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
            gameObject.GetComponent<BoatMovement>().StopBoat();

            AudioManager.Instance.PlaySfx(SfxType.Explosion);
            AudioManager.Instance.PlaySfx(SfxType.GameOver);                  
        }
    }
}
