using UnityEngine;

public class BoatCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.BoxTag || collision.gameObject.tag == Constants.BombTag)
        {
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
            gameObject.GetComponent<BoatMovement>().StopBoat();
        }
    }
}
