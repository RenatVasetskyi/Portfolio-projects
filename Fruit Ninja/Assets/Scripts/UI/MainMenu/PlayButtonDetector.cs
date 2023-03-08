using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonDetector : MonoBehaviour
{
    private float _delay = 1f;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LoadGameScene());    
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }

    private IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(_delay);
        Events.SendOnGameStarted();
        SceneManager.LoadScene(Scenes.Game.ToString());
    }
}
