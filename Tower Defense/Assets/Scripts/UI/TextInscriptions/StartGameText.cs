using System.Collections;
using TMPro;
using UnityEngine;

public class StartGameText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameStartText;   

    [SerializeField] private LeanTweenType _showEaseType;

    private float _openDuration = 0.5f;
    private float _closeDuration = 1f;

    private float _delay = 2f;

    private void Awake()
    {
        EventManager.GameStarted.AddListener(ShowGameStartedText);
    }

    private IEnumerator ShowGameStartedTextCoroutine()
    {
        yield return new WaitForSeconds(_delay);
        LeanTween.scale(_gameStartText.gameObject, Vector3.one, _openDuration).setEase(_showEaseType).setOnComplete(HideGameStartedText);
    }

    private IEnumerator HideGameStartedTextCoroutine()
    {
        yield return new WaitForSeconds(_delay);
        LeanTween.scale(_gameStartText.gameObject, Vector3.zero, _closeDuration);
    }

    private void ShowGameStartedText()
    {
        StartCoroutine(ShowGameStartedTextCoroutine());
    }

    private void HideGameStartedText()
    {
        StartCoroutine(HideGameStartedTextCoroutine());
    }
}
