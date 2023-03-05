using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _gameScore;

    public int GameScore => _gameScore;

    private void Awake()
    {
        Events.OnFruitSliced.AddListener(IncreaseScore);
    }

    private void IncreaseScore()
    {
        _gameScore++;
        _scoreText.text = _gameScore.ToString();
    }
}
