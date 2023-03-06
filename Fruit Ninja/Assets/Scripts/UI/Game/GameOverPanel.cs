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
    private float _delay = 2f;

    private void Awake()
    {
        _backToMenuButton.onClick.AddListener(OnBackToMenuButtonClickHandler);
        _retryButton.onClick.AddListener(OnRetryButtonClickHandler);

        Events.OnGameOver.AddListener(ShowGameOverText);
        Events.OnGameOver.AddListener(StartOpenGameOverPanelCoroutine);
    }

    private void ShowGameOverText()
    {
        LeanTween.scale(_gameOverText.gameObject, Vector3.one, _scaleDuration).setIgnoreTimeScale(true);
    }

    private IEnumerator OpenGameOverPanelCoroutine()
    {
        yield return new WaitForSeconds(_delay);
        _scoreText.text = _score.GetComponent<Score>().GameScore.ToString();
        LeanTween.scale(_gameOverPanel, Vector3.one, _scaleDuration).setIgnoreTimeScale(true);
        _gameOverText.gameObject.SetActive(false);
        AudioManager.Instance.PlaySfx(SfxType.GameOver);
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
