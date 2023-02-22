using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBottle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.BottleTag)
        {
            AudioManager.Instance.PlaySfx(SfxType.TakeBottle);
            Destroy(collision.gameObject);
            EventSystem.SendBottleTaken();
        }       
    }
}
