using System.Collections;
using UnityEngine;

public class BoatCollision : MonoBehaviour
{
    private float _delay = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.BoxTag || collision.gameObject.tag == Constants.BombTag)
        {
            StartCoroutine(GameOverCoroutine());
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
            gameObject.GetComponent<BoatMovement>().StopBoat();
        }
    }

    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(_delay);
        EventSystem.SendGameOver();
    }
}
