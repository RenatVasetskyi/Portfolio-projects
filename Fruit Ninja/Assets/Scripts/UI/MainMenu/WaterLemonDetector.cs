using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterLemonDetector : MonoBehaviour
{
    [SerializeField] private float _delay = 1f;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LoadGameScene());        
    }

    private IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(_delay);
        Events.SendOnGameStarted();
        SceneManager.LoadScene(Scenes.Game.ToString());
    }
}
