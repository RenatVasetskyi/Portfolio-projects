using UnityEngine;

public class BottleBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.PlayerTag)
        {
            PlayTakeBottleSfx();
            DestroyBottle();
            EventSystem.SendBottleTaken();
        }
    }

    private void PlayTakeBottleSfx()
    {
        AudioManager.Instance.PlaySfx(SfxType.TakeBottle);
    }

    private void DestroyBottle()
    {
        Destroy(gameObject);
    }
}
