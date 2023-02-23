using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashIntoTheBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Constants.BoxTag)
        {
            
        }
    }
}
