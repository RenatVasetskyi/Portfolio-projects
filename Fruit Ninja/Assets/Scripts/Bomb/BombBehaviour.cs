using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionParticleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.PlayerTag)
        {
            Events.SendOnGameOver();
            _explosionParticleSystem.Play();
        }
    }
}
