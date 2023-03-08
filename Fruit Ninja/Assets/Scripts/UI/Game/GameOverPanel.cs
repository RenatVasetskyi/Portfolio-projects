using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private Button _retryButton;

    [SerializeField] private GameObject _score;

    private float _scaleDuration = 0.5f;
    private float _gameOverTextdelay = 3f;
    private float _gameOverPanelDelay = 5f;

    private void Awake()
    {
        _backToMenuButton.onClick.AddListener(OnBackToMenuButtonClickHandler);
        _retryButton.onClick.AddListener(OnRetryButtonClickHandler);

        Events.OnBombExploded.AddListener(ShowGameOverText);
        Events.OnBombExploded.AddListener(StartOpenGameOverPanelCoroutine);
    }

    private IEnumerator ShowGameOverTextCoroutine()
    {
        yield return new WaitForSeconds(_gameOverTextdelay);
        LeanTween.scale(_gameOverText.gameObject, Vector3.one, _scaleDuration).setIgnoreTimeScale(true);
    }

    private IEnumerator OpenGameOverPanelCoroutine()
    {
        yield return new WaitForSeconds(_gameOverPanelDelay);
        _scoreText.text = _score.GetComponent<Score>().GameScore.ToString();
        LeanTween.scale(_gameOverPanel, Vector3.one, _scaleDuration).setIgnoreTimeScale(true);
        _gameOverText.gameObject.SetActive(false);
        AudioManager.Instance.PlaySfx(SfxType.GameOver);
    }

    private void ShowGameOverText()
    {
        StartCoroutine(ShowGameOverTextCoroutine());
    }

    private void StartOpenGameOverPanelCoroutine()
    {
        StartCoroutine(OpenGameOverPanelCoroutine());
    }

    private void OnRetryButtonClickHandler()
    {
        Events.SendOnGameStarted();
        AudioManager.Instance.StopSfx();
        SceneManager.LoadScene(Scenes.Game.ToString());
    }

    private void OnBackToMenuButtonClickHandler()
    {
        SceneManager.LoadScene(Scenes.MainMenu.ToString());
    }
}
