using System.Collections;
using TMPro;
using UnityEngine;

public class StartGameText : MonoBehaviour, IShowText
{
    [SerializeField] private TextMeshProUGUI _gameStartText;   

    [SerializeField] private LeanTweenType _showEaseType;

    private float _openDuration = 0.5f;
    private float _closeDuration = 1f;

    private float _delay = 2f;

    public void Show()
    {
        StartCoroutine(ShowGameStartedTextCoroutine());
    }

    public void Hide()
    {
        StartCoroutine(HideGameStartedTextCoroutine());
    }

    private void Awake()
    {
        EventManager.GameStarted.AddListener(Show);
    }

    private IEnumerator ShowGameStartedTextCoroutine()
    {
        yield return new WaitForSeconds(_delay);
        LeanTween.scale(_gameStartText.gameObject, Vector3.one, _openDuration).setEase(_showEaseType).setOnComplete(Hide);
    }

    private IEnumerator HideGameStartedTextCoroutine()
    {
        yield return new WaitForSeconds(_delay);
        LeanTween.scale(_gameStartText.gameObject, Vector3.zero, _closeDuration);
    }
}
