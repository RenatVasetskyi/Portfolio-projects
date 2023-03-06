using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.PlayerTag)
        {
            AudioManager.Instance.PlaySfx(SfxType.Explosion);
            Events.SendOnGameOver();         
        }
    }
}
