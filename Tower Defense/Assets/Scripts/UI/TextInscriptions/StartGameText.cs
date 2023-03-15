using System.Collections;
using TMPro;
using UnityEngine;

public class StartGameText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameStartText;
    [SerializeField] private float _moveDuration = 0.75f;
    [SerializeField] private LeanTweenType _showEaseType;   

    private float _delay = 1f;

    private void Awake()
    {
        EventManager.GameStarted.AddListener(ShowGameStartedText);
    }

    private IEnumerator ShowGameStartedTextCoroutine()
    {
        yield return new WaitForSeconds(_delay);
        LeanTween.scale(_gameStartText.gameObject, Vector3.one, _moveDuration).setEase(_showEaseType).setOnComplete(HideGameStartedText);
    }

    private IEnumerator HideGameStartedTextCoroutine()
    {
        yield return new WaitForSeconds(_delay);
        LeanTween.scale(_gameStartText.gameObject, Vector3.zero, _moveDuration);
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
