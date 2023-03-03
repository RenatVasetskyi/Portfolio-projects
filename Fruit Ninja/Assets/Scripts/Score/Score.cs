using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score;

    private void Awake()
    {
        Events.OnFruitSliced.AddListener(IncreaseScore);
    }

    private void IncreaseScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
}
