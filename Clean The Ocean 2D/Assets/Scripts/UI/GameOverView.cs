using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _finalScoreText;

    [SerializeField] private Button _restart;
    [SerializeField] private Button _backToMenu;   

    [SerializeField] private GameObject _scoreController;

    private float _scaleDuration = 0.2f;

    private void Awake()
    {
        _backToMenu.onClick.AddListener(OnBackToMenuButtonClickHandler);
        _restart.onClick.AddListener(OnRestartButtonClickHandler);
        EventSystem.OnGameOver.AddListener(OpenGameOverView);
    }

    private void OpenGameOverView()
    {
        _finalScoreText.text = $"Final score: <color=green>{_scoreController.GetComponent<GameScore>().Score}</color>";
        LeanTween.scale(_gameOverPanel, Vector3.one, _scaleDuration);
    }

    private void OnBackToMenuButtonClickHandler()
    {
        MainMenu.Instance.OpenMenuPanel();
        SceneManager.LoadScene(Scenes.MainMenu.ToString());
    }

    private void OnRestartButtonClickHandler()
    {
        SceneManager.LoadScene(Scenes.Game.ToString());
        AudioManager.Instance.PlayMusic(MusicType.Game);
        AudioManager.Instance.PlayBoatSfx(BoatSfxType.Engine);
    }
}
