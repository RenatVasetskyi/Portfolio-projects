using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Audio;

namespace UI
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;

        [SerializeField] private TextMeshProUGUI _gameOverText;
        [SerializeField] private TextMeshProUGUI _scoreText;

        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private Button _retryButton;

        [SerializeField] private GameObject _score;

        private float _scaleDuration = 0.3f;
        private float _gameOverTextdelay = 2f;
        private float _gameOverPanelDelay = 4f;

        private void Awake()
        {
            _backToMenuButton.onClick.AddListener(OnBackToMenuButtonClickHandler);
            _retryButton.onClick.AddListener(OnRetryButtonClickHandler);

            Events.OnBombExploded.AddListener(StartShowGameOverText);
            Events.OnBombExploded.AddListener(StartOpenGameOverPanel);
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

        private void StartShowGameOverText()
        {
            StartCoroutine(ShowGameOverTextCoroutine());
        }

        private void StartOpenGameOverPanel()
        {
            StartCoroutine(OpenGameOverPanelCoroutine());
        }

        private void OnRetryButtonClickHandler()
        {
            Events.SendOnGameStarted();
            AudioManager.Instance.StopSfx();
            AudioManager.Instance.PlaySfx(SfxType.Click);
            SceneManager.LoadScene(Scenes.Game.ToString());
        }

        private void OnBackToMenuButtonClickHandler()
        {
            AudioManager.Instance.PlaySfx(SfxType.Click);
            SceneManager.LoadScene(Scenes.MainMenu.ToString());
            Events.SendOnMainMenuOpened();
        }
    }
}
