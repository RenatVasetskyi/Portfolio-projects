using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _finalScoreText;

    [SerializeField] private Button _backToMenu;
    [SerializeField] private Button _quit;

    [SerializeField] private GameObject _scoreController;

    private float _duration = 0.2f;

    private void Awake()
    {
        _backToMenu.onClick.AddListener(OnBackToMenuButtonClickHandler);
        _quit.onClick.AddListener(OnQuitButtonClickHandler);
        EventSystem.OnGameOver.AddListener(LoadGameOverView);
    }

    private void LoadGameOverView()
    {
        _finalScoreText.text = $"Final score: <color=green>{_scoreController.GetComponent<GameScore>().Score}</color>";
        LeanTween.scale(_gameOverPanel, Vector3.one, _duration);
    }

    private void OnBackToMenuButtonClickHandler()
    {
        MainMenu.Instance.OpenMenuPanel();
        SceneManager.LoadScene(Scenes.MainMenu.ToString());
    }

    private void OnQuitButtonClickHandler()
    {
        Application.Quit();
    }
}
